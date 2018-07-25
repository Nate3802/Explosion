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
        Time.timeScale = 1;
	}
	
	// Update is called once per frame
	void Update () {
		if(paused == true)
        {
            pauseBackground.SetActive(true);
            pauseButton.GetComponent<Image>().sprite = playSprite;
        }
        else
        {
            pauseBackground.SetActive(false);
            pauseButton.GetComponent<Image>().sprite = pauseSprite;
        }
	}

    public void PauseGame()
    {
        if (paused == true)
        {
            Time.timeScale = 1;
            paused = false;
        }
        else if (paused == false)
        {
            Time.timeScale = 0;
            paused = true;
        }
    }

    public void LoadLevelScene()
    {
        SceneManager.LoadScene("LevelSelect");
    }

    public void GameOver()
    {
        gameOverBackground.SetActive(true);
        Time.timeScale = 0;
    }

    public void WinGame()
    {
        winBackground.SetActive(true);
        Time.timeScale = 0;
    }
}
