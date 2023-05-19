using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeManager : MonoBehaviour
{
    public static TimeManager instance;
    public TMP_Text minutesTxt;
    public TMP_Text secondsTxt;

    public bool isTimeStarted;
    public float timeValue;

    private void Awake()
    {
        instance = this;
    }

    public void Update()
    {
        if (isTimeStarted)
        {
            timeValue += Time.deltaTime;
            string minutes = Mathf.FloorToInt(timeValue / 60).ToString("00");
            string seconds = Mathf.FloorToInt(timeValue % 60).ToString("00");
            minutesTxt.text = minutes;
            secondsTxt.text = seconds;
        }
        else
        {
            timeValue = 0;
            minutesTxt.text = timeValue.ToString();
            secondsTxt.text = timeValue.ToString();
        }
    }

    public void ResetTimer()
    {
        timeValue = 0;
        minutesTxt.text = timeValue.ToString();
        secondsTxt.text = timeValue.ToString();
    }
}
