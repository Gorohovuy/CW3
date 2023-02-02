using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataFlowManager : MonoBehaviour
{
    public static DataFlowManager Instance;
    public string BestName;
    public string LastName;
    public int BestScore;

    [System.Serializable]
    public class ScoreSavings
    {
        public string BestName;
        public string LastName;
        public int BestScore;
    }

    public void SaveBestScore()
    {
        ScoreSavings data = new ScoreSavings();
        data.BestName = BestName;
        data.BestScore = BestScore;
        data.LastName = LastName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/bestscore.json", json);
    }

    public void LoadBestScore()
    {
        string path = Application.persistentDataPath + "/bestscore.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);

            ScoreSavings data = JsonUtility.FromJson<ScoreSavings>(json);
            BestName = data.BestName;
            LastName = data.LastName;
            BestScore = data.BestScore;
        }
    }

    // Awake is called before the first frame update
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            LoadBestScore();
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
