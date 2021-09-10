using System.Collections;
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

    public int hours;
    public int minutes;
    public float time;
    public int days = 1;
    [SerializeField] float timeScale = 60f;

    [SerializeField] TextMeshProUGUI timeText;
    [SerializeField] TextMeshProUGUI dayText;
    [SerializeField] Light2D globalLight;
    //[SerializeField] Image DayNightPanel;

    [SerializeField] GameObject winPage;

    [SerializeField] Image SleepingFadingPanel;
    [SerializeField] float fadeSpeed;

    bool isChgMusic;

    [SerializeField] AudioClip winReminder;
    bool isPlay;

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
        if (GameManager.instance.isPause)
        {
            if (TorchFunction.isNight)
            {
                if (SoundManager.instance.BGM.isPlaying)
                {
                    SoundManager.instance.BGM.Stop();
                    //SoundManager.instance.BGM.clip = SoundManager.instance.NightBGMMusic;
                    SoundManager.instance.BGM2.Play();
                }
            }
            else
            {
                if (SoundManager.instance.BGM2.isPlaying)
                {
                    SoundManager.instance.BGM2.Stop();
                    //SoundManager.instance.BGM.clip = SoundManager.instance.NightBGMMusic;
                    SoundManager.instance.BGM.Play();
                }
            }
        }

        if (Time.timeScale == 1)
        {
            if (GameManager.instance.isPause == false)
            {
                time += Time.deltaTime * timeScale;
                hours = (int)Hours;
                minutes = (int)Minutes;
                timeText.text = hours.ToString("00") + ":" + minutes.ToString("0") + "0";
                dayText.text = "Day " + days;

                float v = nightTimeCurve.Evaluate(Hours);
                Color c = Color.Lerp(dayLightColor, nightLightColor, v);
                globalLight.color = c;
                //DayNightPanel.color = c;
                if (time > secondsInDay)
                {
                    NextDay();
                }

                if (hours >= 00 && hours < 5)
                {
                    canSleep = CanSleepOrNot.CanSleep;
                }
                else
                {
                    canSleep = CanSleepOrNot.CannotSleep;
                }

                CheckingSleepingStatus();
            }
        }
        EndGame();
        //else
        //{
        //    DayNightPanel.gameObject.SetActive(false);
        //}
    }

    void CheckingNightfunction()
    {
        if(hours > 6 && hours < 8)
        {
            GameManager.instance.isNight = false;
        }
        else
        {
            GameManager.instance.isNight = true;
        }
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
            if(isPlay == false)
            {
                SoundManager.instance.soundEffect.PlayOneShot(winReminder);
                isPlay = true;
            }
            //GameManager.instance.isPause = true;
            winPage.gameObject.SetActive(true);
            GameManager.instance.isPause = false;

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
