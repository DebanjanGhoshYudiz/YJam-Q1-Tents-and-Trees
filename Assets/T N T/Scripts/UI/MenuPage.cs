using UnityEngine;
using UnityEngine.UI;

public class MenuPage : BaseClass
{
    public Button playGameBtn;    
    public Button settingBtn;

    private void Start()
    {
        playGameBtn.onClick.AddListener(OnBtnClick_PlayGame);       
        settingBtn.onClick.AddListener(OnBtnClick_Settings);
    }

    public void OnBtnClick_PlayGame()
    {
        UIManager.iManager.ShowNextScreen(CanvasStates.LevelPage);        
    }
    
    public void OnBtnClick_Settings()
    {
        UIManager.iManager.ShowNextScreen(CanvasStates.SettingPage);
    }
}
