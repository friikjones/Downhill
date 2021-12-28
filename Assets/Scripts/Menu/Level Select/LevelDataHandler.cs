using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

[System.Serializable]
public class LevelData
{
    public int lvlChapter;
    public int lvlNumber;
    // public int[] levelParameters;
    public string lvlName;
    public bool unlocked;
    public int starLevel;

    // public LevelData()
    // {
    //     levelParameters = new int[7];
    // }
}

public static class LevelDataHandler
{
    public static void SaveBinary(LevelData input, int chapter, int number)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/leveldata" + chapter + "-" + number + ".bin";
        FileStream stream = new FileStream(path, FileMode.OpenOrCreate);
        formatter.Serialize(stream, input);
        stream.Close();
        Debug.Log("Data saved @ " + path);
    }

    public static LevelData LoadBinary(int chapter, int number)
    {
        string path = Application.persistentDataPath + "/leveldata" + chapter + "-" + number + ".bin";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            LevelData data = formatter.Deserialize(stream) as LevelData;
            stream.Close();
            Debug.Log("Data loaded from " + path);

            return data;

        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }

    public static void DeleteBinary(int chapter, int number)
    {
        string path = Application.persistentDataPath + "/leveldata" + chapter + "-" + number + ".bin";
        if (File.Exists(path))
        {
            File.Delete(path);
        }
    }

    public static void SavePlain(LevelData input, int chapter, int number)
    {
        string path = Application.persistentDataPath + "/leveldata" + chapter + "-" + number + ".txt";
        StreamWriter writer = new StreamWriter(path, true);
        writer.WriteLine(input.lvlChapter);
        writer.WriteLine(input.lvlNumber);
        // for (int i = 0; i < input.levelParameters.Length; i++)
        // {
        //     writer.WriteLine(input.levelParameters[i]);
        // }
        writer.WriteLine(input.lvlName);
        writer.WriteLine(input.unlocked);
        writer.WriteLine(input.starLevel);
        writer.Close();

        Debug.Log("Plain text save @ " + path);
    }
    public static LevelData LoadPlain(int chapter, int number)
    {
        LevelData output = new LevelData();
        string path = Application.persistentDataPath + "/leveldata" + chapter + "-" + number + ".txt";
        StreamReader reader = new StreamReader(path);
        output.lvlChapter = int.Parse(reader.ReadLine());
        // output.lvlNumber = int.Parse(reader.ReadLine());
        // for (int i = 0; i < 7; i++)
        // {
        //     output.levelParameters[i] = int.Parse(reader.ReadLine());
        // }
        output.lvlName = reader.ReadLine();
        output.unlocked = bool.Parse(reader.ReadLine());
        output.starLevel = int.Parse(reader.ReadLine());
        reader.Close();

        Debug.Log("Plain text loaded from " + path);

        return output;
    }

}
