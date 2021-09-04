using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatusManager : MonoBehaviour
{
    public static PlayerStatusManager instance;

    public float StartCountDown;
    [SerializeField] float DelayedTime;
    bool startToCountDown;

    private void Awake()
    {
        instance = this;
    }

    public Slider PlayerHP;
    public Slider PlayerStamina;
    public Slider PlayerFood;
    public Slider PlayerWater;

    private void Start()
    {
        StartCountDown = Time.time;
    }

    /// <summary>
    /// Checking the temperature and deduct the value is too hot or too cold
    /// </summary>
    private void Update()
    {
        if(TemperatureManager.instance.isCold)
        {
            if (startToCountDown == true)
            {
                if (Time.time >= StartCountDown + DelayedTime)
                {
                    PlayerFood.value -= 30;
                    StartCountDown = Time.time;
                    startToCountDown = false;
                }
            }
            else
            {
                startToCountDown = true;
                StartCountDown = Time.time;
            }
        }

        else
        {
            startToCountDown = false;
        }

        if(TemperatureManager.instance.isHot)
        {
            if (startToCountDown == true)
            {
                if (Time.time >= StartCountDown + DelayedTime)
                {
                    PlayerWater.value -= 30;
                    StartCountDown = Time.time;
                    startToCountDown = false;
                }
            }
            else
            {
                startToCountDown = true;
                StartCountDown = Time.time;
            }
        }

        else
        {
            startToCountDown = false;
        }
    }
}
