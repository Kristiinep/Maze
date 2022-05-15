using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowFullMaze : MonoBehaviour
{
    public Camera mainCamera;
    public GetValues getValues;
    public ChangeMode changeMode;

    private float height, width;
    private float positionX, positionY, positionZ;

    public void ChangeView()
    {
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

        positionX = width / 2;
        positionZ = height / 2;

        //Looks the screen size and positioning to know where to place the camera
        if(width <= 5 && height <= 5)
        {
            positionY = width * 2;
        }
        else if(width >= height)
        {
            positionY = width;
        }
        else if (height > width)
        {
            positionY = height;
        }
        else if (Camera.main.aspect >= 0.5 && Camera.main.aspect < 0.75 && width >= height)
        {
            positionY = positionY * 2;
        }
        else if (Camera.main.aspect >= 0.75 && Camera.main.aspect < 1.3 && width >= height)
        {
            positionY = positionY + height;
        }
        else
        {
            positionY = positionY - (height * 1.5f);
        }
        mainCamera.transform.position = new Vector3(positionX, positionY, positionZ);
    }
}
