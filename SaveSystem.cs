using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class SaveSystem
{

    public static void SaveData<TSaveObject>(TSaveObject saveObject, string filePath) where TSaveObject : class
    {
        BinaryFormatter formatter = new BinaryFormatter();

        string path = Application.persistentDataPath + filePath;

        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, saveObject);
        stream.Close();
    }

    public static TSaveObject LoadData<TSaveObject>(string filePath) where TSaveObject : class
    {
        string path = Application.persistentDataPath + filePath;
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            TSaveObject data = formatter.Deserialize(stream) as TSaveObject;
            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }

}
