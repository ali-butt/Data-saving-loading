using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class DataManager : MonoBehaviour
{
    public Dictionary<string, object> Data = new Dictionary<string, object>();

    string FilePath;

    public static DataManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        FilePath = Path.Combine(Application.persistentDataPath, "GameData.dat");

        // Ensure the file exists or create it if not
        if (!File.Exists(FilePath))
        {
            SaveData(); // Creates the file with empty data
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        LoadData();
    }

    public void AddOrModifyData<T>(string key, T value)
    {
        if (Data.ContainsKey(key))
        {
            Data[key] = value;
        }
        else
        {
            Data.Add(key, value);
        }

        SaveData();
    }

    public void Remove(string key)
    {
        Data.Remove(key);
        SaveData();
    }

    void LoadData()
    {
        try
        {
            if (!File.Exists(FilePath))
                return;

            using (FileStream fileStream = File.Open(FilePath, FileMode.Open))
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                Data = (Dictionary<string, object>)binaryFormatter.Deserialize(fileStream);
            }
        }
        catch (System.Exception e)
        {
            Debug.LogError("Failed to load data: " + e.Message);
        }
    }

    void SaveData()
    {
        try
        {
            using (FileStream fileStream = File.Open(FilePath, FileMode.OpenOrCreate))
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(fileStream, Data);
            }
        }
        catch (System.Exception e)
        {
            Debug.LogError("Failed to save data: " + e.Message);
        }
    }
}
