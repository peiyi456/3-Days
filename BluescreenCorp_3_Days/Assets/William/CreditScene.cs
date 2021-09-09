using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditScene : MonoBehaviour
{
    public TextMeshProUGUI FirstUiCredit;
    public TextMeshProUGUI NextUiCredit;
    public TextMeshProUGUI LastUICredit;
    //1st set
    bool checkAplha;
    float timeCountDown;
    float fadingAplha;
    public bool nextText;
    //2nd set
    bool checkAplha2;
    float timeCountDown2;
    float fadingAplha2;
    public bool nextText2;
    //Main Menu
    float backMainMenu;
    
    // Start is called before the first frame update
    
    void Start()
    {
        NextUiCredit.alpha = 0;
        LastUICredit.alpha = 0;
        checkAplha = true;
        checkAplha2 = false;
        nextText = false;
        nextText2 = false;
    }

    void FirstScene()
    {
        if (checkAplha == true)
        {
            timeCountDown = timeCountDown +Time.deltaTime;
        }
        if (timeCountDown > 5)
        {
            checkAplha = false;
            timeCountDown = 0;
        }
        
        if(checkAplha==false)
        {
            fadingAplha = fadingAplha + Time.deltaTime;
            FirstUiCredit.alpha = 1-fadingAplha;
        }
        if (FirstUiCredit.alpha < 0 && checkAplha == false)
        {
            nextText = true;
        }

        if (nextText == true)
        {
            NextUiCredit.alpha = 1;
            checkAplha2 = true;
        }
    }
    void SecondScene()
    {
        if (checkAplha2 == true)
        {
            timeCountDown2 = timeCountDown2 +Time.deltaTime;
        }
        if (timeCountDown2 > 3)
        {
            checkAplha2 = false;
            timeCountDown2 = 0;
        }
        
        if(checkAplha2==false)
        {
            fadingAplha2 = fadingAplha2 + Time.deltaTime;
            NextUiCredit.alpha = 1-fadingAplha2;
        }
        if (NextUiCredit.alpha < 0 && checkAplha2 == false)
        {
            nextText2 = true;
        }

        if (nextText2 == true)
        {
            
            LastUICredit.alpha = 1;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (nextText == false)
        {
            FirstScene();
        }
        else
        {
            SecondScene();
        }

        if (nextText2 == true)
        {
            backMainMenu = backMainMenu + Time.deltaTime;

            if (backMainMenu > 4)
            {
                SceneManager.LoadScene("MainPage");
            }
        }

    }
}
