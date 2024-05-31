using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance {  get; private set; }

    public string highScorePlayerName;
    public int highScoreRecord;

    public string playerName;
    public int playerScore;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        LoadGameData();
    }

    public void PlayerName(string name)
    {
        Data data = new Data();
        data.name = name;
    } 

    public void HighScore(int score)
    {
        Data highScoreData = new Data();
        highScoreData.highScore = score;
    }

    [System.Serializable]
    class Data
    {
        public string name;
        public int highScore;
    }

    public void SaveGameData()
    {
        Data saveData = new Data();

        if (playerScore > saveData.highScore)
        {
            saveData.highScore = playerScore;
            saveData.name = playerName;

            string json = JsonUtility.ToJson(saveData);

            File.WriteAllText(Application.persistentDataPath + "/saveData.json", json);
        }
    }

    public void LoadGameData()
    {
        string path = Application.persistentDataPath + "/saveData.json";

        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            Data data = JsonUtility.FromJson<Data>(json);

            highScorePlayerName = data.name;
            highScoreRecord = data.highScore;
        }
        else
        {
            highScoreRecord = 0;
        }

        Debug.Log(highScorePlayerName);
        Debug.Log(highScoreRecord);

    }
}
