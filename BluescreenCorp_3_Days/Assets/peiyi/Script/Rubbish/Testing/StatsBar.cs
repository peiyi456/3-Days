using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StatsBar : MonoBehaviour
{
    //Use for deduct the player stats
    [SerializeField] bool isHP; 
    [SerializeField] bool isStamina; 
    [SerializeField] float StartCountDown;
    [SerializeField] float time;
    [SerializeField] float DelayedTime;
    float temp;

    public int maxStatsValue;
    //public float updatedExp;

    public Slider _statBars;
    public float deductValue;

    public TextMeshProUGUI StatsWord;
    public float loseValue;
    public bool isTemperature;
    [SerializeField] GameObject losePage;

    //public float expIncreasedPerSecond;

    //public int playerLevel;
    //public Text levelText;

    [SerializeField] Button testButton;

    private void Start()
    {
        time = DelayedTime;
        StartCountDown = Time.time;
        //playerLevel = 1;
        //expIncreasedPerSecond = 5f;
        _statBars.maxValue = maxStatsValue;
        _statBars.value =_statBars.maxValue;
        StatsWord.text = _statBars.value + "/" + _statBars.maxValue;

        testButton.onClick.AddListener(addStats);
        if(isTemperature)
        {
            _statBars.value = 36f;
            StatsWord.text = _statBars.value + "°C";
        }

        //losePage = GameObject.FindGameObjectWithTag("LosePage");
    }

    void Update()
    {


        //if (GameManager.instance.isPause == false)
        ////if (Time.deltaTime == 1)
        //{
            if (!isStamina)
            {
                //statsBarFunction()
                time -= Time.deltaTime;
                if (time <= 0)
                {
                    Debug.Log("ddd");
                    if (_statBars.value != 0 || _statBars.value == _statBars.maxValue)
                    {
                        _statBars.value -= deductValue;

                        //StartCountDown = Time.time;
                        time = DelayedTime;
                    }
                }
                StatsWord.text = _statBars.value + "/" + _statBars.maxValue;

                if (isTemperature)
                {
                    StatsWord.text = _statBars.value + "°C";
                }

                loseCondition();
                //_statBars.value += expIncreasedPerSecond * Time.deltaTime;
                ////_statBars.value = updatedExp / maxStatsValue;

                //levelText.text = "Level: " + playerLevel;

                //if (_statBars.value >= _statBars.maxValue)
                //{
                //    playerLevel++;
                //    _statBars.value = 0;
                //    _statBars.maxValue += _statBars.maxValue;
                //}
            }

            else if (isStamina)
            {
                time -= Time.deltaTime;
                if (time <= 0)
                {
                    if (_statBars.value != 0 || _statBars.value <= _statBars.maxValue)
                    {
                        _statBars.value += deductValue;

                        //StartCountDown = Time.time;
                        time = DelayedTime;
                    }
                }
                StatsWord.text = _statBars.value + "/" + _statBars.maxValue;
                loseCondition();
            }
        //}
        //else
        //{
        //    StartCountDown = Time.time;
        //}

        Debug.Log(GameManager.instance.isPause);
    }

    //public void statsBarFunction(int statNo)
    //{
    //    if (Time.time >= StartCountDown + DelayedTime[statNo])
    //    {
    //        if (_statBars[statNo].value != 0)
    //        {
    //            _statBars[statNo].value -= 1.0f;
    //            StartCountDown = Time.time;
    //        }
    //    }
    //}

    void addStats()
    {
        _statBars.value += 5.0f;
    }

    void loseCondition()
    {
        if(_statBars.value <= loseValue)
        {
            losePage.SetActive(true);
            Time.timeScale = 0;
        }

        if(isTemperature == true)
        {
            if(_statBars.value > 45f)
            {
                //GameObject.FindGameObjectWithTag("LosePage").SetActive(true);
                Time.timeScale = 0;
            }
        }
    }
}
