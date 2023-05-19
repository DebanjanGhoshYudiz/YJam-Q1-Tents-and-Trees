using UnityEngine;
using UnityEngine.UI;

public class GameRulesPage : BaseClass
{
    public Button gameRulesOkBTn;

    private void Start()
    {
        gameRulesOkBTn.onClick.AddListener(OnBtnClick_BackToSettings);
    }

    public void OnBtnClick_BackToSettings()
    {
        UIManager.iManager.ShowNextScreen(CanvasStates.SettingPage);
    }
}
