﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerStatusManager : MonoBehaviour
{
    public static PlayerStatusManager instance;

    public float StartCountDown;
    public float timeForTemperature;
    public float timeForStats;
    [SerializeField] float DelayedTimeForTemperature;
    [SerializeField] float DelayedTimeForStats;
    bool startToCountDown;

    private void Awake()
    {
        instance = this;
    }

    [Header("Player status bar")]
    public Slider PlayerHP;
    public Slider PlayerStamina;
    public Slider PlayerFood;
    public Slider PlayerWater;

    [Header("Player status max value")]
    [SerializeField] float hpMax;
    [SerializeField] float foodMax;
    [SerializeField] float waterMax;
    [SerializeField] float staminaMax;

    [Header("Player status deduct/add value per min")]
    [SerializeField] float foodDeductValue;
    [SerializeField] float foodDeductValue_Cold;
    [SerializeField] float waterDeductValue;
    [SerializeField] float waterDeductValue_Hot;
    [SerializeField] float staminaAddValue;

    [Header("Pages related to the player status")]
    [SerializeField] GameObject losePage;
    [SerializeField] GameObject lowHPEffect;

    private void Start()
    {
        StartCountDown = Time.time;
        timeForTemperature = DelayedTimeForTemperature;
        timeForStats = DelayedTimeForStats;

        InitializeStatsValue();
    }

    void InitializeStatsValue()
    {
        PlayerHP.maxValue = hpMax;
        PlayerStamina.maxValue = staminaMax;
        PlayerWater.maxValue = waterMax;
        PlayerFood.maxValue = foodMax;

        PlayerHP.value = PlayerHP.maxValue;
        PlayerStamina.value = PlayerStamina.maxValue;
        PlayerWater.value = PlayerWater.maxValue;
        PlayerFood.value = PlayerFood.maxValue;
    }

    /// <summary>
    /// Checking the temperature and deduct the value is too hot or too cold
    /// </summary>
    private void Update()
    {
        TextUpdating();
        if (GameManager.instance.isPause == false)
        {
            if (TemperatureManager.instance.isCold)
            {
                if (startToCountDown == true)
                {
                    timeForTemperature -= Time.deltaTime;
                    if (timeForTemperature <= 0)
                    {
                        timeForTemperature = DelayedTimeForTemperature;
                        PlayerFood.value -= foodDeductValue_Cold;
                        //PlayerFood.GetComponentInChildren<TextMeshProUGUI>().text = PlayerFood.value + "/" + PlayerFood.maxValue;
                        //StartCountDown = Time.time;
                        startToCountDown = false;
                    }
                }
                else
                {
                    startToCountDown = true;
                    //StartCountDown = Time.time;
                    timeForTemperature = DelayedTimeForTemperature;
                }
            }

            //else
            //{
            //    startToCountDown = false;
            //}

            else if (TemperatureManager.instance.isHot)
            {
                if (startToCountDown == true)
                {
                    timeForTemperature -= Time.deltaTime;
                    if (timeForTemperature <= 0)
                    {
                        PlayerWater.value -= waterDeductValue_Hot;
                        //StartCountDown = Time.time;
                        timeForTemperature = DelayedTimeForTemperature;
                        startToCountDown = false;
                    }
                }
                else
                {
                    startToCountDown = true;
                    //StartCountDown = Time.time;
                    timeForTemperature = DelayedTimeForTemperature;
                }
            }

            else
            {
                startToCountDown = false;
                timeForTemperature = DelayedTimeForTemperature;
            }

            if(PlayerHP.value < 5)
            {
                lowHPEffect.SetActive(true);
            }

            StatsUpdateFunc();
            LoseCondition();
        }

        //else
        //{
        //    startToCountDown = false;
        //    //StartCountDown = Time.time;
        //    //time = DelayedTime;
        //}
    }

    void StatsUpdateFunc()
    {
        timeForStats -= Time.deltaTime;
        if (timeForStats <= 0)
        {
            Debug.Log("ddd");
            if (PlayerFood.value > 0)
            {
                PlayerFood.value -= foodDeductValue;

                //StartCountDown = Time.time;

                //PlayerFood.GetComponentInChildren<TextMeshProUGUI>().text = PlayerFood.value + "/" + PlayerFood.maxValue;
            }

            if (PlayerWater.value > 0)
            {
                PlayerWater.value -= waterDeductValue;

                //StartCountDown = Time.time;

                //PlayerWater.GetComponentInChildren<TextMeshProUGUI>().text = PlayerWater.value + "/" + PlayerWater.maxValue;
            }

            if (PlayerStamina.value < PlayerStamina.maxValue)
            {
                PlayerStamina.value += staminaAddValue;

                //StartCountDown = Time.time;

                //PlayerStamina.GetComponentInChildren<TextMeshProUGUI>().text = PlayerStamina.value + "/" + PlayerStamina.maxValue;
            }
                timeForStats = DelayedTimeForStats;
        }

        //PlayerHP.GetComponentInChildren<TextMeshProUGUI>().text = PlayerHP.value + "/" + PlayerHP.maxValue;
    }

    void LoseCondition()
    {
        if(PlayerFood.value <= 0 || PlayerWater.value <= 0 || PlayerStamina.value <= 0 || PlayerHP.value <= 0)
        {
            losePage.SetActive(true);
            Time.timeScale = 0;
        }
    }

    void TextUpdating()
    {
        PlayerFood.GetComponentInChildren<TextMeshProUGUI>().text = PlayerFood.value + "/" + PlayerFood.maxValue;
        PlayerWater.GetComponentInChildren<TextMeshProUGUI>().text = PlayerWater.value + "/" + PlayerWater.maxValue;
        PlayerStamina.GetComponentInChildren<TextMeshProUGUI>().text = PlayerStamina.value + "/" + PlayerStamina.maxValue;
        PlayerHP.GetComponentInChildren<TextMeshProUGUI>().text = PlayerHP.value + "/" + PlayerHP.maxValue;

    }
}
