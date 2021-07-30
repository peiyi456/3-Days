using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Experimental.Rendering.Universal;

public class DayTimeManager : MonoBehaviour
{
    const float secondsInDay = 86400f;

    [SerializeField] Color nightLightColor;
    [SerializeField] AnimationCurve nightTimeCurve;
    [SerializeField] Color dayLightColor = Color.white;

    public float time;
    public int days = 1;
    [SerializeField] float timeScale = 60f;

    [SerializeField] TextMeshProUGUI timeText;
    [SerializeField] TextMeshProUGUI dayText;
    [SerializeField] Light2D globalLight;
    [SerializeField] Image DayNightPanel;

    [SerializeField] GameObject winPage;

    float Hours
    {
        get { return time / 3600f; }
    }

    float Minutes
    {
        get { return time % 3600f / 600f; }
    }

    private void Update()
    {
        if (GameManager.instance.isPause == false)
        {
            time += Time.deltaTime * timeScale;
            int hh = (int)Hours;
            int mm = (int)Minutes;
            timeText.text = hh.ToString("00") + ":" + mm.ToString("0") + "0";
            dayText.text = "Day " + days;

            float v = nightTimeCurve.Evaluate(Hours);
            Color c = Color.Lerp(dayLightColor, nightLightColor, v);
            //globalLight.color = c;
            DayNightPanel.color = c;
            if (time > secondsInDay)
            {
                NextDay();
            }
        }
        EndGame();
        //else
        //{
        //    DayNightPanel.gameObject.SetActive(false);
        //}
    }

    private void NextDay()
    {
        time = 0;
        days += 1;
    }

    void EndGame()
    {
        if(days > 3)
        {
            GameManager.instance.isPause = true;
            winPage.gameObject.SetActive(true);
        }
    }

}
