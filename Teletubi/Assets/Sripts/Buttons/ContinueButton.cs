using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContinueButton : MonoBehaviour
{
    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        if (GameManager.instance.savedGame)
        {
            button.onClick.AddListener(OnButtonClick);
        }
        else
        {
            Debug.Log("No saved game to continue");
        }
    }

    private void OnButtonClick()
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.LoadCurrentGame();
        }
        else
        {
            Debug.Log("GameManager.instance is null");
        }
    }
}