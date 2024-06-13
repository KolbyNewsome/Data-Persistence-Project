using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance;
    public TMP_InputField nameField;
    public string playerName;
    public string currentPlayer;
    public int score;

    [System.Serializable]
    class SaveData
    {
        public string playerName;
        public int score;
    }

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(this);
        SaveManager.Instance.LoadScore();
        nameField.text = SaveManager.Instance.playerName;
    }

    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.playerName = playerName;
        data.score = score;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            playerName = data.playerName;
            score = data.score;
        }

    }
}
