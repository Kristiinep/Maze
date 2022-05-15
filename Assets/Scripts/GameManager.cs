using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject generatingMaze, player, playButton, backButton, gameLight, generatorLight;

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
            Application.Quit();
    }
    public void StartGame()
    {
        generatingMaze.SetActive(false);
        player.SetActive(true);
        backButton.SetActive(true);
        playButton.SetActive(false);
        gameLight.SetActive(true);
        generatorLight.SetActive(false);
        RenderSettings.fog = true;

    }

    public void EndGame()
    {
        generatingMaze.SetActive(true);
        player.SetActive(false);
        backButton.SetActive(false);
        gameLight.SetActive(false);
        generatorLight.SetActive(true);
        RenderSettings.fog = false;
    }
}
