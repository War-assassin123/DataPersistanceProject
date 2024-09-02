using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SocialPlatforms.Impl;

public class DataManager : MonoBehaviour
{
    public string highScoreText;
    public int highScore;
    private int incomingScore = 0;
    public static DataManager instance;
    public string playerName;
    private InputGrabber grabber;
    private MainManager mainManager;
    private void Start()
    {
        grabber = GameObject.Find("Player Name Input").GetComponent<InputGrabber>();
        highScoreText = new string("High Score:");
        LoadHighScore();
    }
    public void GetPlayerName()
    {
        playerName = grabber.playerName;
    }
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    public void CheckHighScore()
    {
        mainManager = GameObject.Find("MainManager").GetComponent<MainManager>();
        incomingScore = mainManager.m_Points;
        if (incomingScore > highScore)
        {
            highScore = incomingScore;
            highScoreText = new string("High Score:" + playerName + ":" + highScore);
            SaveHighScore();
        } 
    }
    [System.Serializable]
    class SaveData
    {
        public string highScoreText;
        public int highScore;
    }
    public void SaveHighScore()
    {
        SaveData data = new SaveData();
        data.highScoreText = highScoreText;
        data.highScore = highScore;
        string Json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json",Json);
    }
    public void LoadHighScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            highScoreText = data.highScoreText;
            highScore = data.highScore;
        }
    }
}
