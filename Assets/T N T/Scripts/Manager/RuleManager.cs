/*
    Rule To Check In Game If They Are Been Followed
    Rules :
    1. Tents Cannot Exceed the column and row number
    2. Tents Cannot be placed next to each other in 'Diagonal, Horizontal, Vertical' to each other
    3. Tents can only be place next to tree in Horizontal or Vertical position of a tree
    4. You Cannot Place Tents besides a tree Diagonally.(If the trees are generated next to each other then it wont check for diagonal)

    Hint Provide Instructions;
    Will check which of the rule is broke and will provide a solution or will just generate the text of which particular rule is broke
*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RuleManager : MonoBehaviour
{
    public static RuleManager instance;

    public string s;

    private void Awake()
    {
        instance = this;
    }

    public void RuleBroke(Rules rules)
    {
        switch (rules)
        {
            case Rules.Rule1:                          
                s = "Tents cannot Exceed the column and row number";
                Debug.Log("Rule 1 Broke "+s);
                PopUpMessage.instance.popUpCanvas.enabled = true;
                PopUpMessage.instance.SetMessageText(s,0);
                break;

            case Rules.Rule2:
                s = "Tents cannot be placed next to each other";
                Debug.Log("Rule 2 Broke "+s);
                PopUpMessage.instance.popUpCanvas.enabled = true;
                PopUpMessage.instance.SetMessageText(s,1);
                break;

            case Rules.Rule3:
                s = "Tents can only be placed next to tree in horizontal and vertical positon";
                Debug.Log("Rule 3 Broke "+s);
                PopUpMessage.instance.popUpCanvas.enabled = true;
                PopUpMessage.instance.SetMessageText(s,2);
                break;

            case Rules.Rule4:
                s = "Cannnot place tents besdies a tree Diagonally";
                Debug.Log("Rule 4 Broke "+s);
                PopUpMessage.instance.popUpCanvas.enabled = true;
                PopUpMessage.instance.SetMessageText(s,3);
                break;

            default:
                break;
        }
    }    
}
