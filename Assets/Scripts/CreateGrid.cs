using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateGrid : MonoBehaviour
{
    public float height, width;
    public GameObject plane;
    public GameObject wallPrefab1, wallPrefab2, wallPrefab3, wallPrefab4, wallPrefab5, wallPrefab6, wallPrefab7, wallPrefab8, wallPrefab9, wallPrefab10;
    public GetValues getHeightWidth;
    public List<GameObject> walls;
    public ChangeMode changeMode;

    private int choosingWall;
    private GameObject wall, wallPrefab;
    private float heightLeft, widthLeft;
    private float startPointX, startPointZ;

    private void Start()
    {
        walls = new List<GameObject>();
    }

    public void GenerateVertical()
    {

        SetValues();
        startPointX = 0f;
        startPointZ = 0.5f;

        ResizePlane();
        while (widthLeft >= 0)
        {
            while (heightLeft > 0)
            {
                ChooseWalls();
                wall = Instantiate(wallPrefab, new Vector3(startPointX, 0.5f, startPointZ), Quaternion.identity);
                walls.Add(wall);
                startPointZ ++;
                heightLeft--;
            }
            heightLeft = height;
            startPointZ = 0.5f;
            startPointX ++;
            widthLeft--;
        }
    }
    public void GenerateHorizontal()
    {
        SetValues();
        startPointX = 0.5f;
        startPointZ = 0f;

        while (heightLeft >= 0)
        {
            while (widthLeft > 0)
            {
                ChooseWalls();
                wall = Instantiate(wallPrefab, new Vector3(startPointX, 0.5f, startPointZ), Quaternion.identity);
                wall.transform.Rotate(0.0f, 90.0f, 0.0f, Space.Self);
                walls.Add(wall);
                startPointX ++;
                widthLeft--;
            }
            widthLeft = width;
            startPointX = 0.5f;
            startPointZ ++;
            heightLeft--;
        }
    }

    private void SetValues()
    {
        if(changeMode.isGameMode == true)
        {
            height = getHeightWidth.heightGame;
            width = getHeightWidth.widthGame;
        }
        else
        {
            height = getHeightWidth.height;
            width = getHeightWidth.width;
        }
        heightLeft = height;
        widthLeft = width;
    }

    private void ChooseWalls()
    {
        if (changeMode.isGameMode == true)
        {
            //Chooses a random wall prefab to use
            choosingWall = Random.Range(1, 8);
            WallPrefab(choosingWall);

        }
        else
        {
            //Generation mode uses only one type of walls
            wallPrefab = wallPrefab1;
        }
    }

    private void WallPrefab(int prefabWall)
    {
        switch(prefabWall)
        {
            case int prefabNr when prefabNr == 1:
                wallPrefab = wallPrefab1;
                break;
            case int prefabNr when prefabNr == 2:
                wallPrefab = wallPrefab2;
                break;
            case int prefabNr when prefabNr == 3:
                wallPrefab = wallPrefab3;
                break;
            case int prefabNr when prefabNr == 4:
                wallPrefab = wallPrefab4;
                break;
            case int prefabNr when prefabNr == 5:
                wallPrefab = wallPrefab5;
                break;
            case int prefabNr when prefabNr == 6:
                wallPrefab = wallPrefab6;
                break;
            case int prefabNr when prefabNr == 7:
                wallPrefab = wallPrefab7;
                break;
            case int prefabNr when prefabNr == 8:
                wallPrefab = wallPrefab8;
                break;
            case int prefabNr when prefabNr == 9:
                wallPrefab = wallPrefab9;
                break;
            case int prefabNr when prefabNr == 10:
                wallPrefab = wallPrefab10;
                break;
        }
    }

    private void ResizePlane()
    {
        //Takes the input size and calculates the plane size
        plane.transform.localScale = new Vector3(width*0.1f, transform.localScale.y, height*0.1f);
        plane.transform.position = new Vector3(width / 2, 0f, height / 2);
    }
}
