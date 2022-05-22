using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private LevelData levelData;

    private GameObject winPanel;
    private GameObject buttons;
    private GameObject pauseMenu;
    private GameObject nextLevelButton;

    int curretSceneId;
    int sceneCount;

    private void Awake()
    {
        Time.timeScale = 1;
        winPanel = GameObject.Find("Win");
        buttons = GameObject.Find("Buttons");
        pauseMenu = GameObject.Find("PauseMenu");
        nextLevelButton = GameObject.Find("NextLevel");

        curretSceneId = SceneManager.GetActiveScene().buildIndex;
        sceneCount = SceneManager.sceneCountInBuildSettings;
        if (sceneCount - 1 == curretSceneId)
        {
            nextLevelButton.SetActive(false);
        }
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
        levelData.levelPassed[curretSceneId - 1] = true; 
    }

    public void NextLevel()
    {
        if (sceneCount - 1 != curretSceneId)
        {
            SceneManager.LoadScene(curretSceneId + 1);
        }
    }
}
