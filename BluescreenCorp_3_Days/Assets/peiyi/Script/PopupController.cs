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

    [SerializeField] GameObject PlayerNote;
    [SerializeField] GameObject PausePage;
    [SerializeField] GameObject SettingPage;
    [SerializeField] Slider volumeSlider;
    public TextMeshProUGUI MuteUnmuteText;
    public Toggle SoundToggle;
    public static bool isMute;
    public float soundVolume;
    string newVolume = "VOLUME_SLIDER";

    [SerializeField] GameObject Books;
    [SerializeField] GameObject MapPage;

    bool isPause;
    bool isBookOpen;
    bool isPausePageOpen;
    bool isMapOpen;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0;
        PausePage.SetActive(false);
        PlayerNote.SetActive(true);

        isPause = false;
        isPausePageOpen = false;
        isBookOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        UIPopup();

    }

    void PauseResumeGame()
    {
        if (isPause == true)
        {
            Time.timeScale = 0;
        }

        else
        {
            Time.timeScale = 1;
        }
    }

    void checkingPauseGame(bool panelOnOff)
    {
        isPause = panelOnOff;
    }

    void UIPopup()
    {
        if (Time.timeScale == 1)
        {
            if (!isMapOpen)
            {
                if (Input.GetKeyDown(KeyCode.B))
                {
                    isBookOpen = !isBookOpen;
                    CharacterController2D.instance.stopMove = isBookOpen;
                    if (isBookOpen)
                    {
                        GameManager.instance.isPause = true;
                        RectTransform rt = Books.GetComponent<RectTransform>();
                        rt.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, 0, rt.rect.width);
                        rt.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, 0, rt.rect.height);

                    }
                    else
                    {
                        GameManager.instance.isPause = false;

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
                        GameManager.instance.isPause = true;

                        isMapOpen = true;
                        CharacterController2D.instance.stopMove = isMapOpen;
                        MapPage.SetActive(isMapOpen);
                    }

                    else
                    {
                        GameManager.instance.isPause = false;

                        isMapOpen = false;
                        CharacterController2D.instance.stopMove = isMapOpen;
                        MapPage.SetActive(isMapOpen);
                    }
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!GameManager.instance.isPause)
            {
                if (PlayerNote.activeSelf == false)
                {
                    if (Time.timeScale == 1)
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
                }

                else
                {
                    isPausePageOpen = !isPausePageOpen;
                    PausePage.SetActive(isPausePageOpen);
                }
            }

            else
            {
                isPausePageOpen = !isPausePageOpen;
                PausePage.SetActive(isPausePageOpen);
            }
        }

    }

    public void OnClickResume()
    {
        //isPause = false;
        Time.timeScale = 1;
        isPausePageOpen = false;
        PausePage.SetActive(isPausePageOpen);
    }

    public void OnClickSetting()
    {
        SettingPage.SetActive(true);
    }

    public void OnClickBackToHome()
    {
        MainPageButtonController.isBackMenu = true;
        LoadingPageScripts.loadSceneNumber = 0;
        Time.timeScale = 1;
        Debug.Log("Run: " + Time.timeScale);
        SceneManager.LoadScene(2);
    }

    public void CloseSetting()
    {
        SettingPage.SetActive(false);
    }

    public void OnMouseEnterFunc(Button buttons)
    {
        SoundManager.instance.soundEffect.PlayOneShot(mouseEnterSound);
        buttons.GetComponentInChildren<TextMeshProUGUI>().color = Color.yellow;
    }

    public void OnMouseExitFunc(Button buttons)
    {
        buttons.GetComponentInChildren<TextMeshProUGUI>().color = Color.white;
    }

    public void OnMouseClickFunc()
    {
        SoundManager.instance.soundEffect.PlayOneShot(mouseClickSound);
    }

    public void OnClickStartTheGame()
    {
        PlayerNote.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
