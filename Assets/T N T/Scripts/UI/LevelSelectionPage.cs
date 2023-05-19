using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectionPage : BaseClass
{
    public Button backMenuBtn;

    public LevelButton levelButtonPrefab;
    public Transform levelBtnParent;

    private void Start()
    {
        backMenuBtn.onClick.AddListener(OnBtnClick_LevelToMenu);
    }

    public void OnBtnClick_LevelToMenu()
    {
        UIManager.iManager.ShowNextScreen(CanvasStates.MenuPage);
    }    

    public override void ShowCanvas()
    {
        base.ShowCanvas();
        //instantiate the level prefab based on your grid level
        for (int i = 0; i < LevelManager.instance.levelDataList.Count; i++)
        {
            int index = i;
            LevelButton levelBtn = Instantiate(levelButtonPrefab, levelBtnParent);
            levelBtn.SetData(index, LevelManager.instance.levelDataList[index].isLocked);
        }
    }

    public override void HideCanvas()
    {
        if (levelBtnParent.childCount != 0)
        {
            for (int i = levelBtnParent.childCount-1 ; i >= 0 ; i--)
            {
                Destroy(levelBtnParent.GetChild(i).gameObject);
            }
        }
        base.HideCanvas();
    }
}
