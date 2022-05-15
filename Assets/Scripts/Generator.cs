using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Generator : MonoBehaviour
{
    public CreateMaze createMaze;
    public CreateGrid createGrid;
    public CleanMaze cleanMaze;
    public ShowFullMaze mazeInView;
    public GameObject playButton, errorMessage;
    public GetValues heightWidth;
    public ChangeMode changeMode;
    public Text errorMessageText;

    // Start is called before the first frame update
    public void GenerateMaze()
    {
        if ((heightWidth.width <= 0 || heightWidth.height <= 0 || heightWidth.height > 250 || heightWidth.width > 250) && changeMode.isGameMode == false)
        {
            errorMessageText.text = "Width and height must be between 1 and 250.";
            errorMessage.SetActive(true);
        }
        else if ((heightWidth.widthGame <= 0 || heightWidth.heightGame <= 0 || heightWidth.heightGame > 10 || heightWidth.widthGame > 10) && changeMode.isGameMode == true)
        {
            errorMessageText.text = "Width and height must be between 1 and 10.";
            errorMessage.SetActive(true);
        }
        else
        {
            errorMessage.SetActive(false);
            cleanMaze.DeleteMaze();
            createGrid.GenerateVertical();
            createGrid.GenerateHorizontal();
            mazeInView.ChangeView();
            createMaze.MazeAlgorithm();
            if(changeMode.isGameMode == true)
            {
                playButton.SetActive(true);
            }
            else
            {
                playButton.SetActive(false);
            }
        }
    }
}
