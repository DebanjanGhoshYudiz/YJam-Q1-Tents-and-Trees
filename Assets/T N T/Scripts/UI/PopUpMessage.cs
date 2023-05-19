using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PopUpMessage : MonoBehaviour
{
    public static PopUpMessage instance;

    public TMP_Text showMessageTxt;  

    public Canvas popUpCanvas;    

    private void Awake()
    {
        instance = this;
    }    

    public void SetMessageText(string s, int priority)
    {        
        switch (priority)
        {
            case 0:
                showMessageTxt.text = " ";
                showMessageTxt.text = s;
                Debug.Log("Message Execute " + showMessageTxt.text);
                Invoke("HidePopUpCanvas", 1.5f);
                break;

            case 1:
                showMessageTxt.text = " ";
                showMessageTxt.text = s;
                Debug.Log("Message Execute " + showMessageTxt.text);
                Invoke("HidePopUpCanvas", 1.5f);
                break;

            case 2:
                showMessageTxt.text = " ";
                showMessageTxt.text = s;
                Debug.Log("Message Execute " + showMessageTxt.text);
                Invoke("HidePopUpCanvas", 1.5f);
                break;

            case 3:
                showMessageTxt.text = " ";
                showMessageTxt.text = s;
                Debug.Log("Message Execute " + showMessageTxt.text);
                Invoke("HidePopUpCanvas", 1.5f);
                break;

            default:                
                break;
        }   
    }

    public void HidePopUpCanvas()
    {
        popUpCanvas.enabled = false;
    }

}
