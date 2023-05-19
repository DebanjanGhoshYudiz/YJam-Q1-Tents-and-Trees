using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameScreenPage : BaseClass
{
    public Button menuBtn;
    public Button retryLevelBtn;
    public Button hintBtn;
        

    public void Start()
    {
        menuBtn.onClick.AddListener(OnBtnClick_BackToMenupage);
        retryLevelBtn.onClick.AddListener(OnBtnClick_RestartLevel);
        hintBtn.onClick.AddListener(OnBtnClick_GetHint);

    }

    public void OnBtnClick_BackToMenupage()
    {
        UIManager.iManager.ShowNextScreen(CanvasStates.MenuPage);
        Level levels = LevelManager.instance.currentLevels;
        levels.OnDestroy();
    }

    public void OnBtnClick_RestartLevel()
    {
        //delete the prefab
        Level levels = LevelManager.instance.currentLevels;
        levels.OnDestroy();

        TimeManager.instance.ResetTimer();

        //Genrate the prefab        
        LevelManager.instance.LoadLevel(LevelManager.instance.currentLevelIndex, LevelTypes.x5);
    }

    public void OnBtnClick_GetHint()
    {
        //get hint for next move
    }

    public override void ShowCanvas()
    {
        base.ShowCanvas();
        TimeManager.instance.isTimeStarted = true;        
    }

    public override void HideCanvas()
    {
        TimeManager.instance.isTimeStarted = false;
        PopUpMessage.instance.HidePopUpCanvas();
        base.HideCanvas();
    }

}
