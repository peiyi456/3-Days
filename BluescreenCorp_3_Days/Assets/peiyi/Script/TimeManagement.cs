using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimeManagement : MonoBehaviour
{
    public float startCountDown;

    public TextMeshProUGUI _RealTime;

    public TextMeshProUGUI _gameDay;
    public TextMeshProUGUI _gameTime;
    public TextMeshProUGUI _gameDayInbook;
    public TextMeshProUGUI _gameHourInbook;
    public TextMeshProUGUI _gameMinuteInbook;
    string[] _Minute = new string[] { "00", "10", "20", "30", "40", "50"};
    string[] _Hour = new string[] {   "00", "01", "02", "03", "04", "05", "06", 
                                  "07", "08", "09", "10", "11", "12", "13", 
                                  "14", "15", "16", "17", "18", "19", "20", 
                                  "21", "22", "23" };
    int h, m;                         

    float _hour, _minute, _maxHour, _maxMinute;
    float _addedTime = 4.167f;

    float _dayNo = 1;

    // Start is called before the first frame update
    void Start()
    {
        h = 0;
        m = 0;
        _maxHour = 24;
        _maxMinute = 50;
        startCountDown = Time.time;
        _hour = 8;
        _minute = 00;
        
    }

    // Update is called once per frame
    void Update()
    {
        _RealTime.text = Time.time.ToString();
        TimeDayUpdated();
    }

    void TimeDayUpdated()
    {
        _gameTime.text = _Hour[h] + ":" + _Minute[m];
        _gameDay.text = "Day " + _dayNo;
        _gameDayInbook.text = _dayNo.ToString();
        _gameHourInbook.text = _Hour[h];
        _gameMinuteInbook.text = _Minute[m];


        if (Time.time >= startCountDown + _addedTime)
        {
            if (m != _Minute.Length)
            {
                m++;
                if(m == _Minute.Length)
                {
                    m = 0;
                    h++;
                }
            }

            if(h == _Hour.Length)
            {
                h = 0;
                _dayNo++;
            }
            //else
            //{
            //    m = 0;
            //    if (h != _Hour.Length)
            //    {
            //        h++;
            //    }

            //    else
            //    {
            //        h = 0;
            //        _dayNo++;
            //    }
            //}
            startCountDown = Time.time;
        }
    }
}
