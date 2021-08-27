using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeSystem : MonoBehaviour
{
    //[Range(0, 24)] public float timeOfDay;
    [Range(0, 24)] public int day;
    [Range(0f, 0.602f)]public float minute;
    [SerializeField] float timeSpeed = 60f;

    [SerializeField] Color nightLightColor;
    [SerializeField] AnimationCurve nightTimeCurve;
    [SerializeField] Color dayLightColor = Color.white;

    [SerializeField] TextMeshProUGUI timeText;
    [SerializeField] TextMeshProUGUI dayText;
    [SerializeField] Image DayNightPanel;

    [SerializeField] GameObject winPage;

    float timeScale = 60f;

    float Hours
    {
        get { return day; }
    }

    float Minutes
    {
        get { return minute % 1f; }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.isPause == false)
        {
            TimeCalculation();

            Debug.Log(minute);
        }
    }

    void TimeCalculation()
    {
        //timeOfDay += Time.deltaTime * timeSpeed;

        //timeOfDay %= 24;
        minute += Time.deltaTime * timeSpeed;
        minute %= 0.602f;

        if(minute >= 0.6)
        {
            day++;
        }
    }
}
