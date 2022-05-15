using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetValues : MonoBehaviour
{
    public InputField heightInput, widthInput, heightInputGame, widthInputGame;
    public float height, width, heightGame, widthGame;
    public ChangeMode changeMode;

    public void getInputValues()
    {
        //Depending on the active mode, takes input 
        if(changeMode.isGameMode == true)
        {
            heightGame = float.Parse(heightInputGame.text);
            widthGame = float.Parse(widthInputGame.text);
        }
        else
        {
            height = float.Parse(heightInput.text);
            width = float.Parse(widthInput.text);
        }

    }
}
