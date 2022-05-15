using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeMode : MonoBehaviour
{
    public bool isGameMode = false;
    public GameObject height, width, heightGame, widthGame;
    public Text modeText;

    public void ChangeGameMode()
    {
        //Checks what mode is currently active and changes to opposite one
        if(isGameMode)
        {
            isGameMode = false;
            height.SetActive(true);
            width.SetActive(true);
            heightGame.SetActive(false);
            widthGame.SetActive(false);
            modeText.text = "game mode";
        }
        else
        {
            isGameMode = true;
            height.SetActive(false);
            width.SetActive(false);
            heightGame.SetActive(true);
            widthGame.SetActive(true);
            modeText.text = "generation mode";
        }
    }
}
