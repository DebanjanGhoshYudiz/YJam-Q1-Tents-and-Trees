using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public List<LevelData> levelDataList = new List<LevelData>();
    public Transform levelParent;
    public Level currentLevels;
    public Level loadedLevel;
    public int currentLevelIndex;

    public bool isLevelSet;

    private void Awake()
    {
        instance = this;
        isLevelSet = false;
    }

    public void LoadLevel(int index, LevelTypes types)
    {
        
        if (levelParent.childCount != 0)
        {
            for (int i = levelParent.childCount - 1; i >= 0; i--)
            {
                Destroy(levelParent.GetChild(i).gameObject);
            }
        }
        isLevelSet = true;
        loadedLevel = Instantiate(levelDataList[index].levelPrefab, levelParent);
        currentLevels = loadedLevel;
        currentLevelIndex = index;
        Debug.Log(loadedLevel);
    }

    public LevelData GetNextLevelData()
    {
        if (currentLevelIndex >= levelDataList.Count-1)
            return null;
        else
            return levelDataList[currentLevelIndex + 1];
    }

    public LevelData GetLevelData(int index)
    {
        return levelDataList[index];
    }
}

    [System.Serializable]
    public class LevelData
    {
        public bool isLocked;
        public Level levelPrefab;
    }

