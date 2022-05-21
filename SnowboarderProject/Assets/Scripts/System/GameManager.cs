using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private GameObject winPanel;
    private GameObject buttons;
    private GameObject pauseMenu;


    int curretSceneId;

    private void Awake()
    {
        Time.timeScale = 1;
        winPanel = GameObject.Find("Win");
        buttons = GameObject.Find("Buttons");
        pauseMenu = GameObject.Find("PauseMenu");

        curretSceneId = SceneManager.GetActiveScene().buildIndex;
    }

    private void Start()
    {
        pauseMenu.SetActive(false);
        winPanel.SetActive(false);


    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void Restart()
    {
        SceneManager.LoadScene(curretSceneId);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void Win()
    {
        winPanel.SetActive(true);
        buttons.SetActive(false);
    }
}
