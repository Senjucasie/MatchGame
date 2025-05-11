using Core;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;

public class SaveManager : MonoBehaviour
{

    [SerializeField]private string _filePath;
    private const string _fileName = "Game.json";

    private void Awake()
    {
        _filePath = Path.Combine(Application.persistentDataPath,_fileName);
    }

    public void SaveGame(SaveData savedata)
    {
        string json = JsonUtility.ToJson(savedata); 
        File.WriteAllText(_filePath, json);
        Debug.Log( "Filepath is" + _filePath);
    }

    public SaveData LoadGame() 
    {
       
        if (File.Exists(_filePath))
        {
            string json = File.ReadAllText(_filePath);
            SaveData data = JsonUtility.FromJson<SaveData>(json);
            return data;
        }
        else
        {
            return null;
        }
    }

    [ContextMenu("Clear cache")]
    public void ClearCache()
    {
        if (File.Exists(_filePath))
        {
            Debug.Log("Deleting");
            File.Delete(_filePath);
        }
    }
}


[Serializable]
public class SaveData
{
    public List<PersistCard> PersistCardData;
    public LevelData CurrentLevel;
    public int Score;

    public SaveData(List<PersistCard> persistCardData, LevelData currentLevel,int score)
    {
        PersistCardData = persistCardData;
        CurrentLevel = currentLevel;
        Score = score;
    }
}

[Serializable]
public class PersistCard
{
    public int CardType;
    public CardState State;

    public PersistCard(int  cardype, CardState state)
    {
        CardType = cardype;
        State = state;
    }
}
