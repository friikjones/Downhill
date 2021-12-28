using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class LevelManager : MonoBehaviour
{
    public int chapters, lvlPerChapter;
    public LevelData testInput;
    public List<LevelData> levelDataList;


    // private void Start()
    // {
    //     testInput = new LevelData();
    // }



    public void SaveMemoryList()
    {
        foreach (LevelData level in levelDataList)
        {
            LevelDataHandler.SaveBinary(level, level.lvlChapter, level.lvlNumber);
        }
    }

    public void LoadSavedList()
    {
        LevelData level = new LevelData();
        bool listExists = false;
        if (levelDataList.Count > 0)
            listExists = true;
        for (int i = 0; i < chapters; i++)
        {
            for (int j = 0; j < lvlPerChapter; j++)
            {
                level = LevelDataHandler.LoadBinary(i, j);
                if (listExists)
                {
                    levelDataList[(i * lvlPerChapter) + j] = level;
                }
                else
                {
                    levelDataList.Add(level);
                }
            }
        }
    }

    public void DropMemoryList()
    {
        levelDataList.Clear();
    }

    public void DropSavedList()
    {
        for (int i = 0; i < chapters; i++)
        {
            for (int j = 0; j < lvlPerChapter; j++)
            {
                LevelDataHandler.DeleteBinary(i, j);
            }
        }
    }

    public void SavePlainList()
    {
        for (int i = 0; i < chapters; i++)
        {
            for (int j = 0; j < lvlPerChapter; j++)
            {
                levelDataList[(i * lvlPerChapter) + j].lvlChapter = i;
                levelDataList[(i * lvlPerChapter) + j].lvlNumber = j;
            }
        }

        foreach (LevelData level in levelDataList)
        {
            LevelDataHandler.SavePlain(level, level.lvlChapter, level.lvlNumber);
        }
    }
    public void LoadPlainList()
    {
        LevelData level = new LevelData();
        bool listExists = false;
        if (levelDataList.Count > 0)
            listExists = true;
        for (int i = 0; i < chapters; i++)
        {
            for (int j = 0; j < lvlPerChapter; j++)
            {
                level = LevelDataHandler.LoadPlain(i, j);
                if (listExists)
                {
                    levelDataList[(i * lvlPerChapter) + j] = level;
                }
                else
                {
                    levelDataList.Add(level);
                }
            }
        }
    }

}
