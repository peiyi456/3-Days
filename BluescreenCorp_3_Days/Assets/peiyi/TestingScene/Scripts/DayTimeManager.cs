﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Experimental.Rendering.Universal;
using DG.Tweening;

public enum CanSleepOrNot{CanSleep, CannotSleep}
public enum PlayerSleepingStatus { Sleep, Wake}

public class DayTimeManager : MonoBehaviour
{
    public static DayTimeManager instance;

    private void Awake()
    {
        instance = this;
    }

    public CanSleepOrNot canSleep;
    public PlayerSleepingStatus sleepStatus;

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

    [SerializeField] Image SleepingFadingPanel;
    [SerializeField] float fadeSpeed;

    float Hours
    {
        get { return time / 3600f; }
    }

    float Minutes
    {
        get { return time % 3600f / 600f; }
    }

    private void Start()
    {
        sleepStatus = PlayerSleepingStatus.Wake;
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

            if(hh >= 22 && hh < 24)
            {
                canSleep = CanSleepOrNot.CanSleep;
            }
            else if(hh >= 00 && hh < 02)
            {
                canSleep = CanSleepOrNot.CanSleep;
            }
            else
            {
                canSleep = CanSleepOrNot.CannotSleep;
            }

            CheckingSleepingStatus();
        }
        EndGame();
        //else
        //{
        //    DayNightPanel.gameObject.SetActive(false);
        //}
    }

    private void NextDay()
    {
        if (sleepStatus == PlayerSleepingStatus.Sleep)
        {
            time = 28800;
        }
        else
        {
            time = 0;
        }
        days += 1;
        sleepStatus = PlayerSleepingStatus.Wake;
        PlayerStatusManager.instance.PlayerFood.value = PlayerStatusManager.instance.PlayerFood.maxValue;
        PlayerStatusManager.instance.PlayerWater.value = PlayerStatusManager.instance.PlayerWater.maxValue;
        PlayerStatusManager.instance.PlayerStamina.value = PlayerStatusManager.instance.PlayerStamina.maxValue;
        //PlayerStatusManager.instance.PlayerFood.value = PlayerStatusManager.instance.PlayerFood.maxValue;
    }

    void EndGame()
    {
        if(days > 3)
        {
            GameManager.instance.isPause = true;
            winPage.gameObject.SetActive(true);
        }
    }

    void CheckingSleepingStatus()
    {
        if(sleepStatus == PlayerSleepingStatus.Sleep)
        {
            //StartCoroutine(SleepingAnimation(fadeSpeed));
            PlaySleepingFadeAnimation(fadeSpeed);
            NextDay();
        }
    }

    public void PlaySleepingFadeAnimation(float time)
    {
        var sequence = DOTween.Sequence();
        sequence.Join(SleepingFadingPanel.DOFade(255f, time / 2));
        sequence.Join(SleepingFadingPanel.DOFade(0f, time / 2));
    }

    IEnumerator SleepingAnimation(float time)
    {
        var sequence = DOTween.Sequence();
        sequence.Join(SleepingFadingPanel.DOFade(255f, time / 2));
        sequence.Join(SleepingFadingPanel.DOFade(0f, time / 2));

        yield return new WaitForSeconds(time);
    }

}