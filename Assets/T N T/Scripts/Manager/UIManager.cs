using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager iManager;

    public List<BaseClass> screenList;
        
    BaseClass currentScreen;
    
    public void Awake()
    {
        iManager = this;
        currentScreen = screenList[0];
    }

    public void ShowNextScreen(CanvasStates canvasStates)
    {
        currentScreen.HideCanvas();
        screenList[(int)canvasStates].ShowCanvas();
        currentScreen = screenList[(int)canvasStates];
    }


    public BaseClass GetScreen(CanvasStates cs)
    {
        return screenList[(int)cs];
    }    
}
