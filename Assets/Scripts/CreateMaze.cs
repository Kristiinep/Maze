using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMaze : MonoBehaviour
{   
    public CreateGrid mazeInfo;
    public ChangeMode changeMode;
    public GetValues getValues;


    private float startX, startZ, newSquareX, newSquareZ, visitedSquareX, visitedSquareZ, squaresTotal;
    private List<KeyValuePair<float, float>> visitedPlaces;
    private List<GameObject> walls;
    private float height, width;
    private bool isVisited;

    private float counter;

    private float visitedInRow;

    public void MazeAlgorithm()
    {
        startX = 0.5f;
        startZ = 0.5f;
        visitedPlaces = new List<KeyValuePair<float, float>>();
        visitedPlaces.Add(new KeyValuePair<float, float>(startX, startZ));
        newSquareX = startX;
        newSquareZ = startZ;
        if(changeMode.isGameMode == true)
        {
            height = getValues.heightGame;
            width = getValues.widthGame;
        }
        else
        {
            height = getValues.height;
            width = getValues.width;
        }
        walls = mazeInfo.walls;

        squaresTotal = height * width;
        counter = 0;

        while (squaresTotal != visitedPlaces.Count)
        {
            //Moves to new place
            moveToNewSquare();

            //Checks if the place is out of maze area.
            if (newSquareX < 0 || newSquareX > width || newSquareZ < 0 || newSquareZ > height)
            {
                //If the place is out of the maze area, then moves back to last visited square.
                newSquareX = visitedSquareX;
                newSquareZ = visitedSquareZ;
            }
            else
            {
                isVisited = false;
                //Finds if the new place is visited.
                //If yes then isVisited is true, otherwise always false.
                for (int r = 0; r < visitedPlaces.Count; r++)
                {
                    if (visitedPlaces[r].Key == newSquareX && visitedPlaces[r].Value == newSquareZ)
                    {
                        isVisited = true;
                        visitedInRow++;
                        break;
                    }
                }
                //After 40000 squares in a row are already visited, then starts to look unvisited one row by row from the beginning
                if(visitedInRow == 40000)
                {
                    FindUnvisitedSquare();
                    visitedInRow = 0;
                    counter++;
                    Debug.Log("Counter " + counter);
                }
                if (isVisited == false)
                {
                    DeleteWall();
                }
            }
        }
    }

    private void moveToNewSquare()
    {
        //Before moving to new square it saves the current square values
        visitedSquareX = newSquareX;
        visitedSquareZ = newSquareZ;

        //Decides randomly if the new step is one step forward, one step backward or same spot on the X axis.
        float rand = Random.Range(-1, 2);
        newSquareX = newSquareX + rand;

        //If the new step stays on the same place on X axis then it moves on the Z axis.
        //Randomly one step up or one step down.
        if (rand == 0)
        {
            float rand2 = Random.Range(0, 2) == 0 ? -1f : 1f;
            newSquareZ = newSquareZ + rand2;
        }
    }

    private void DeleteWall()
    {

        //Adds square value to visited list
        visitedPlaces.Add(new KeyValuePair<float, float>(newSquareX, newSquareZ));
        
        //Finds a wall between the square it is in and the one it came from
        float deleteX = (newSquareX + visitedSquareX) / 2;
        float deleteZ = (newSquareZ + visitedSquareZ) / 2;
        Vector3 deleteWall = new Vector3(deleteX, 0.5f, deleteZ);

        //Finds the wall that needs to be deleted from the walls list and deletes it
        for (int n = 0; n < walls.Count; n++)
        {
            Vector3 wallInList = new Vector3(walls[n].transform.position.x, walls[n].transform.position.y, walls[n].transform.position.z);
            if (wallInList == deleteWall)
            {
                GameObject.Destroy(walls[n]);
                break;
            }
        }
    }

    private void FindUnvisitedSquare()
    {
        newSquareX = startX;
        newSquareZ = startZ;
        bool alreadyVisited = false;

        while(isVisited)
        {
            visitedSquareX = newSquareX;
            visitedSquareZ = newSquareZ;
            newSquareX++;
            if(newSquareX > width)
            {
                newSquareZ++;
                newSquareX = startX;
            }
            for(int n = 0; n < visitedPlaces.Count; n++)
            {
                //Looks if this square is already visited
                if(newSquareX == visitedPlaces[n].Key && newSquareZ == visitedPlaces[n].Value)
                {
                    alreadyVisited = true;
                    break;
                }
                else
                {
                    alreadyVisited = false;
                }
            }
            if(alreadyVisited == false)
            {
                if(newSquareZ != visitedSquareZ)
                {
                    visitedSquareX = startX;
                }
                DeleteWall();
                return;
            }
        }
    }
}
