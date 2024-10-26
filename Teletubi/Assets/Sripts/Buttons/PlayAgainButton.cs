using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayAgainButton : MonoBehaviour
{
    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.LoadGame();
        }
        else
        {
            Debug.Log("GameManager.instance is null");
        }
    }
}