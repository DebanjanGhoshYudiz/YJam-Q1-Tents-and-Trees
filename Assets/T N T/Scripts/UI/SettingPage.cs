using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingPage : BaseClass
{
    public Button gameRulesBtn;
    public Button okBtn;

    private void Start()
    {
        gameRulesBtn.onClick.AddListener(OnBtnClick_GameRule);
        okBtn.onClick.AddListener(OnBtnClick_SettingToMenu);
    }

    public void OnBtnClick_GameRule()
    {
        UIManager.iManager.ShowNextScreen(CanvasStates.GameRulePage);
    }

    public void OnBtnClick_SettingToMenu()
    {
        UIManager.iManager.ShowNextScreen(CanvasStates.MenuPage);
    }
}
