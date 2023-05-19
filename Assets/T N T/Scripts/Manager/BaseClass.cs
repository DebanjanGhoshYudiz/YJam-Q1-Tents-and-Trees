using UnityEngine;
using UnityEngine.UI;

public class BaseClass : MonoBehaviour
{
    [HideInInspector]
    public Canvas myCanvas;    

    public void Awake()
    {
        myCanvas = GetComponent<Canvas>();
    }

    public virtual void ShowCanvas()
    {
        myCanvas.enabled = true;        
    }

    public virtual void HideCanvas()
    {
        myCanvas.enabled = false;
    }
}
