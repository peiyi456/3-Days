using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PopupController : MonoBehaviour
{
    [SerializeField] GameObject Setting;
    [SerializeField] Slider volumeSlider;
    public TextMeshProUGUI MuteUnmuteText;
    public Toggle SoundToggle;
    public static bool isMute;
    public float soundVolume;
    string newVolume = "VOLUME_SLIDER";

    [SerializeField] GameObject Book;
    bool isPause;
    bool isOpen;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        Setting.SetActive(false);
        //Book.SetActive(false);
        isPause = false;

        ///This is use for volume setting part, but i not yet completed///
        //string mute = PlayerPrefs.GetString("Sound Off", "true");
        //volumeSlider.value = PlayerPrefs.GetFloat(newVolume, 1);

        //// Get boolean using PlayerPrefs
        //isMute = PlayerPrefs.GetInt("isMute") == 1 ? true : false;
        //if (isMute == false)
        //{
        //    AudioListener.volume = 0;
        //    MuteUnmuteText.text = "Sound On";
        //    PlayerPrefs.SetString("Sound Off", "true");

        //    //Save boolean using PlayerPrefs
        //    PlayerPrefs.SetInt("isMute", isMute ? 1 : 0);
        //    isMute = true;
        //}

        //else
        //{
        //    AudioListener.volume = volumeSlider.value;
        //    MuteUnmuteText.text = "Sound Off";
        //    PlayerPrefs.SetString("Sound Off", "false");
        //    PlayerPrefs.SetInt("isMute", isMute ? 1 : 0);
        //    isMute = false;
        //}
    }

    // Update is called once per frame
    void Update()
    {
        UIPopup();

        //if (isPause)
        //{
        //    Time.timeScale = 0;
        //}

        //else
        //{
        //    Time.timeScale = 1;
        //}


    }

    void UIPopup()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            isPause = !isPause;
            isOpen = !isOpen;
            //Book.SetActive(isOpen);
            if(isOpen)
            {
                RectTransform rt = Book.GetComponent<RectTransform>();
                rt.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, 0, rt.rect.width);
                rt.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, 0, rt.rect.height);
            }
            else
            {
                RectTransform rt = Book.GetComponent<RectTransform>();
                rt.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, 1920, rt.rect.width);
                rt.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, 0, rt.rect.height);
            }

            if(Time.timeScale != 0)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
        }

        if(Input.GetKeyDown(KeyCode.Escape))
        {
            isPause = !isPause;
            isOpen = !isOpen;
            Setting.SetActive(isOpen);

            if (Time.timeScale != 0)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
        }
    }
}
