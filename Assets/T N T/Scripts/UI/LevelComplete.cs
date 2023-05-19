using UnityEngine;
using UnityEngine.UI;

public class LevelComplete : BaseClass
{
    public Button nextLevelBtn;
    public Button menuBtn;

    private void Start()
    {
        nextLevelBtn.onClick.AddListener(OnBtnClick_NextLevel);
        menuBtn.onClick.AddListener(OnBtnClick_CurrentLevelToMenu);
    }

    public void OnBtnClick_NextLevel()
    {
        //go to next level from current level
        LevelData nextLevelData = LevelManager.instance.GetNextLevelData();
        if (nextLevelData != null)
        {
            nextLevelData.isLocked = false;
            LevelManager.instance.LoadLevel(LevelManager.instance.currentLevelIndex + 1, LevelTypes.x5);
            UIManager.iManager.ShowNextScreen(CanvasStates.GamePage);
        }
        else
        {
            UIManager.iManager.ShowNextScreen(CanvasStates.MenuPage);
        }
    }

    public void OnBtnClick_CurrentLevelToMenu()
    {
        UIManager.iManager.ShowNextScreen(CanvasStates.MenuPage);
    }
}
