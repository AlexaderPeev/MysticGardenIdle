using System.IO;
using UnityEngine;

public class JsonDatabase : MonoBehaviour
{
    private string filePath;
    public ItemDatabase database;

    private void Awake()
    {
        filePath = Path.Combine(Application.persistentDataPath, "items.json");
        database = LoadData();
    }

    private void OnApplicationQuit()
    {
        SaveData(database);
    }

    public void SaveData(ItemDatabase database)
    {
        string json = JsonUtility.ToJson(database, true);
        File.WriteAllText(filePath, json);
        Debug.Log("Data saved to: " + filePath);
    }

    public ItemDatabase LoadData()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            return JsonUtility.FromJson<ItemDatabase>(json);
        }
        Debug.LogWarning("File not found, returning empty database");
        return new ItemDatabase();
    }
}
