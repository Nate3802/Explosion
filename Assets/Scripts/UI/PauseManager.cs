using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour {

    public bool paused;
    public GameObject pauseBackground;
    public Button pauseButton;
    public Sprite playSprite;
    public Sprite pauseSprite;

    public GameObject gameOverBackground;

    public GameObject winBackground;

	// Use this for initialization
	void Start () {
        //Time scale is normal
        Time.timeScale = 1;
	}
	
	// Update is called once per frame
	void Update () {
        //If game is paused
		if(paused == true)
        {
            //Turn on pause UI
            pauseBackground.SetActive(true);
            //Change PauseButton to PlayButton sprite
            pauseButton.GetComponent<Image>().sprite = playSprite;
        }
        //If game is not paused
        else
        {
            //Turn off pause UI
            pauseBackground.SetActive(false);
            //Change PlayButton to PauseButton sprite
            pauseButton.GetComponent<Image>().sprite = pauseSprite;
        }
	}

    //When pause button is clicked
    public void PauseGame()
    {
        if (paused == true)
        {
            //Normalize time scale
            Time.timeScale = 1;
            //Change paused to false
            paused = false;
        }
        else if (paused == false)
        {
            //Stop time except for animations checked to be unscaled time
            Time.timeScale = 0;
            //Change paused to true
            paused = true;
        }
    }

    public void LoadLevelScene()
    {
        //Load level select screen
        SceneManager.LoadScene("LevelSelect");
    }

    public void GameOver()
    {
        //Turn on game over UI
        gameOverBackground.SetActive(true);
        //Pause time 
        Time.timeScale = 0;
    }

    public void WinGame()
    {
        //Turn on Win Level UI 
        winBackground.SetActive(true);
        //Pause time
        Time.timeScale = 0;
    }
}
