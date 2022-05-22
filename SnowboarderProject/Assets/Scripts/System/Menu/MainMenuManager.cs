using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField]
    private GameObject mainMenu;
    [SerializeField]
    private GameObject levelSelector;

    private void Start()
    {
        levelSelector.SetActive(false);
    }

    public void ActiveLevelSelector(bool value)
    {
        if (value)
        {
            mainMenu.SetActive(false);
            levelSelector.SetActive(true);
        }
        else
        {
            mainMenu.SetActive(true);
            levelSelector.SetActive(false);
        }
    }

    public void LoadScene(Level level)
    {
        SceneManager.LoadScene(level.id + 1);
    }
}
