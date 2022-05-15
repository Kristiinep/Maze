using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanMaze : MonoBehaviour
{
    public CreateGrid wallsInfo;
    private List<GameObject> wallsList;

    public void DeleteMaze()
    {
        wallsList = wallsInfo.walls;
        //If the walls list is not empty, then it will destroy all the objects there and then clear the list.
        if (wallsList.Count != 0)
        {
            foreach (GameObject walls in wallsList)
            {
                GameObject.Destroy(walls);
            }
            wallsList.Clear();
        }
    }
}
