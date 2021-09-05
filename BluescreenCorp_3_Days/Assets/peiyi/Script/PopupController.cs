using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PopupController : MonoBehaviour
{
    [SerializeField] AudioClip mouseEnterSound;
    [SerializeField] AudioClip mouseClickSound;
    [SerializeField] GameObject PausePage;
    [SerializeField] GameObject SettingPage;
    [SerializeField] Slider volumeSlider;
    public TextMeshProUGUI MuteUnmuteText;
    public Toggle SoundToggle;
    public static bool isMute;
    public float soundVolume;
    string newVolume = "VOLUME_SLIDER";

    [SerializeField] GameObject Books;
    //[SerializeField] GameObject CharacterPage;
    //[SerializeField] GameObject InventoryPage;
    //[SerializeField] GameObject CraftingPage;
    [SerializeField] GameObject MapPage;

    bool isPause;
    bool isBookOpen;
    bool isPausePageOpen;
    bool isMapOpen;

    // Start is called before the first frame update
    void Start()
    {
        //GameManager.instance.isPause = false;
        Time.timeScale = 1;
        PausePage.SetActive(false);
        //InventoryPage.SetActive(false);
        //CharacterPage.SetActive(false);
        isPause = false;
        isPausePageOpen = false;
        isBookOpen = false;
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
        //checkingPauseGame(isBookOpen);
        UIPopup();
        //PauseResumeGame();

    }

    void PauseResumeGame()
    {
        if (isPause == true)
        {
            //GameManager.instance.isPause = true;
            Time.timeScale = 0;
        }

        else
        {
            //GameManager.instance.isPause = false;
            Time.timeScale = 1;
        }
    }

    void checkingPauseGame(bool panelOnOff)
    {
        isPause = panelOnOff;
    }

    void UIPopup()
    {
        if (!isMapOpen)
        {
            if (Input.GetKeyDown(KeyCode.B))
            {
                
                isBookOpen = !isBookOpen;
                if (isBookOpen)
                {
                    RectTransform rt = Books.GetComponent<RectTransform>();
                    rt.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, 0, rt.rect.width);
                    rt.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, 0, rt.rect.height);

                }
                else
                {
                    RectTransform rt = Books.GetComponent<RectTransform>();
                    rt.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, 1920, rt.rect.width);
                    rt.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, 0, rt.rect.height);
                }
            }
        }

        if (!isBookOpen)
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                if (isMapOpen == false)
                {
                    isMapOpen = true;
                    MapPage.SetActive(isMapOpen);
                }

                else
                {
                    isMapOpen = false;
                    MapPage.SetActive(isMapOpen);
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPause == false)
            {
                isPausePageOpen = true;
                PausePage.SetActive(isPausePageOpen);
                isPause = true;
                Time.timeScale = 0;
            }

            else
            {
                isPausePageOpen = false;
                PausePage.SetActive(isPausePageOpen);
                isPause = false;
                Time.timeScale = 1;
            }
            //checkingPauseGame(isPausePageOpen);
        }

    }

    public void OnClickResume()
    {
        isPause = false;
        Time.timeScale = 1;
        isPausePageOpen = false;
        PausePage.SetActive(isPausePageOpen);
        //checkingPauseGame(isPausePageOpen);
    }

    public void OnClickSetting()
    {
        SettingPage.SetActive(true);
    }

    public void OnClickBachHome()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }

    public void CloseSetting()
    {
        SettingPage.SetActive(false);
    }

    public void OnMouseEnterFunc(Button buttons)
    {
        GameManager.instance.soundEffect.PlayOneShot(mouseEnterSound);
        buttons.GetComponentInChildren<TextMeshProUGUI>().color = Color.yellow;
    }

    public void OnMouseExitFunc(Button buttons)
    {
        buttons.GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
    }

    public void OnMouseClickFunc()
    {
        GameManager.instance.soundEffect.PlayOneShot(mouseClickSound);
    }
}
