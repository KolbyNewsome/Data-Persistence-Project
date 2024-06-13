using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEditor;

public class StartMenu : MonoBehaviour
{
    public TMP_InputField nameField;
    public string playerName;

    public void StartGame()
    {
        playerName = nameField.text;

        if (playerName.Trim() != "")
        {
            SaveManager.Instance.currentPlayer = playerName;
            SceneManager.LoadScene("main");
        }
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
