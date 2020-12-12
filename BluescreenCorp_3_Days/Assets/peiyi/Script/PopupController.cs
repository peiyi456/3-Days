using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PopupController : MonoBehaviour
{
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
        if (!isPausePageOpen && !isMapOpen)
        {
            if (Input.GetKeyDown(KeyCode.B))
            {
                if (Time.timeScale == 1)
                {
                    Time.timeScale = 0;
                }

                else
                {
                    Time.timeScale = 1;
                }

                isBookOpen = !isBookOpen;
                checkingPauseGame(isBookOpen);
                //CharacterPage.SetActive(isOpen);
                if (isBookOpen)
                {
                    RectTransform rt = Books.GetComponent<RectTransform>();
                    rt.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, 0, rt.rect.width);
                    rt.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, 0, rt.rect.height);
                    //CharacterPage.gameObject.GetComponent<Canvas>().sortingOrder = 0;

                }
                else
                {
                    RectTransform rt = Books.GetComponent<RectTransform>();
                    rt.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, 1920, rt.rect.width);
                    rt.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, 0, rt.rect.height);
                }
            }

            //else if (Input.GetKeyDown(KeyCode.I))
            //{
            //    if (isPause)
            //    {
            //        if (InventoryPage.gameObject.GetComponent<Canvas>().sortingOrder != 0)
            //        {
            //            CharacterPage.gameObject.GetComponent<Canvas>().sortingOrder = -1;
            //            InventoryPage.gameObject.GetComponent<Canvas>().sortingOrder = 0;
            //            MapPage.gameObject.GetComponent<Canvas>().sortingOrder = -1;
            //            CraftingPage.gameObject.GetComponent<Canvas>().sortingOrder = -1;
            //        }
            //        else
            //        {
            //            InventoryPage.gameObject.GetComponent<Canvas>().sortingOrder = -1;
            //            CharacterPage.gameObject.GetComponent<Canvas>().sortingOrder = 0;
            //            MapPage.gameObject.GetComponent<Canvas>().sortingOrder = -1;
            //            CraftingPage.gameObject.GetComponent<Canvas>().sortingOrder = -1;
            //        }
            //    }

            //}

            //else if (Input.GetKeyDown(KeyCode.M))
            //{
            //    if (isPause)
            //    {
            //        if (MapPage.gameObject.GetComponent<Canvas>().sortingOrder != 0)
            //        {
            //            MapPage.gameObject.GetComponent<Canvas>().sortingOrder = 0;

            //        }
            //        else
            //        {
            //            MapPage.gameObject.GetComponent<Canvas>().sortingOrder = -1;

            //        }

            //    }

            //}

            //else if (Input.GetKeyDown(KeyCode.C))
            //{
            //    if (isPause)
            //    {
            //        if (MapPage.gameObject.GetComponent<Canvas>().sortingOrder != 0)
            //        {
            //            MapPage.gameObject.GetComponent<Canvas>().sortingOrder = -1;
            //            InventoryPage.gameObject.GetComponent<Canvas>().sortingOrder = -1;
            //            CharacterPage.gameObject.GetComponent<Canvas>().sortingOrder = -1;
            //            CraftingPage.gameObject.GetComponent<Canvas>().sortingOrder = 0;
            //        }
            //        else
            //        {
            //            MapPage.gameObject.GetComponent<Canvas>().sortingOrder = -1;
            //            InventoryPage.gameObject.GetComponent<Canvas>().sortingOrder = -1;
            //            CharacterPage.gameObject.GetComponent<Canvas>().sortingOrder = -1;
            //            CraftingPage.gameObject.GetComponent<Canvas>().sortingOrder = 0;
            //        }

            //    }

            //}
        }

        if (!isBookOpen && !isBookOpen)
        {
            if (Input.GetKeyDown(KeyCode.M))
            {

                if (Time.timeScale == 1)
                {
                    isMapOpen = true;
                    Time.timeScale = 0;
                    MapPage.SetActive(isMapOpen);
                    //RectTransform rt = MapPage.GetComponent<RectTransform>();
                    //rt.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, -100, rt.rect.width);
                    //rt.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, -20, rt.rect.height);
                    //MapPage.gameObject.GetComponent<Canvas>().sortingOrder = 0;
                }

                else
                {
                    isMapOpen = false;
                    Time.timeScale = 1;
                    MapPage.SetActive(isMapOpen);
                    //RectTransform rt = MapPage.GetComponent<RectTransform>();
                    //rt.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, 1920, rt.rect.width);
                    //rt.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, 0, rt.rect.height);
                    //MapPage.gameObject.GetComponent<Canvas>().sortingOrder = -1;
                }

                //isMapOpen = !isMapOpen;
                

                //if (isMapOpen)
                //{
                //    if (MapPage.gameObject.GetComponent<Canvas>().sortingOrder != 0)
                //    {
                //        RectTransform rt = MapPage.GetComponent<RectTransform>();
                //        rt.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, 0, rt.rect.width);
                //        rt.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, 0, rt.rect.height);
                //        MapPage.gameObject.GetComponent<Canvas>().sortingOrder = 0;

                //    }
                //    else
                //    {
                //        RectTransform rt = MapPage.GetComponent<RectTransform>();
                //        rt.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, 1920, rt.rect.width);
                //        rt.SetInsetAndSizeFromParentEdge(RectTransform.Edge.Top, 0, rt.rect.height);
                //        MapPage.gameObject.GetComponent<Canvas>().sortingOrder = -1;

                //    }

                //}


            }

            if (!isBookOpen && !isMapOpen)
            {
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    if (Time.timeScale == 1)
                    {
                        isPausePageOpen = true;
                        PausePage.SetActive(isPausePageOpen);
                        Time.timeScale = 0;
                    }

                    else
                    {
                        isPausePageOpen = false;
                        PausePage.SetActive(isPausePageOpen);
                        Time.timeScale = 1;
                    }
                    //checkingPauseGame(isPausePageOpen);
                }
            }
        }

        
    }

    public void OnClickResume()
    {
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
    }

    public void CloseSetting()
    {
        SettingPage.SetActive(false);
    }
}
