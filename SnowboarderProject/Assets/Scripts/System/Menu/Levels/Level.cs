using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class Level : MonoBehaviour
{
    public int id;

    [SerializeField]
    private LevelData levelData;
    [SerializeField]
    private GameObject blockImage;
    [SerializeField]
    private bool blocked;

    private TMP_Text text;

    private Button button;

    private void OnValidate()
    {
        button = GetComponent<Button>();
        text = GetComponentInChildren<TMP_Text>();
        id = gameObject.name[gameObject.name.Length - 2] - '0';
        text.text = System.Convert.ToString(id + 1);
    }

    private void Update()
    {
        if (id != 0)
        {
            if (levelData.levelPassed[id - 1])
            {
                blocked = false;
            }
        }

        Blocked(blocked);
    }

    private void Blocked(bool value)
    {
        if (value)
        {
            blockImage.SetActive(true);
            button.enabled = false;
        }
        else
        {
            blockImage.SetActive(false);
            button.enabled = true;
        }
    }
}
