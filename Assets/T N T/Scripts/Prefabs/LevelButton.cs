using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelButton : MonoBehaviour
{
    public TMP_Text levelNoTxt;
    public Sprite lockSprite;
    public Button levelBtn;
    public Image levelBtnImage;

    public int btnIndex;    

    //refrence to btn on onenable
    //
    private void OnEnable()
    {
        levelBtn.onClick.AddListener(OnClick_LoadLevel);
    }

    private void OnDisable()
    {
        levelBtn.onClick.RemoveListener(OnClick_LoadLevel);
    }

    public void SetData(int index, bool isLocked)
    {        
        btnIndex = index;
        if(!isLocked)
        {
            levelNoTxt.text = (btnIndex + 1).ToString();
            levelBtnImage.sprite = null;
            levelBtnImage.color = new Color32(255, 255, 255, 0);
        }
        else
        {
            levelBtnImage.sprite = lockSprite;
            levelBtnImage.color = new Color32(255, 255, 255, 255);
        }
    }

    public void OnClick_LoadLevel()
    {
        LevelData levelData = LevelManager.instance.GetLevelData(btnIndex);
        if (levelData.isLocked) return;
        LevelManager.instance.LoadLevel(btnIndex, LevelTypes.x5);
        UIManager.iManager.ShowNextScreen(CanvasStates.GamePage);
    }
}
