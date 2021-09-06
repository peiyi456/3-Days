using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CampFireInteract : MonoBehaviour
{
    public static CampFireInteract instace;

    GameObject player;
    public GameObject PopupMessage;
    public float distance;
    public KeyCode keycode;
    public bool isPressButton;
    public GameObject CookingPanel;
    public GameObject ProgressBar;
    public bool doneCooking;

    private void Awake()
    {
        instace = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        PopupMessage.GetComponentInChildren<TextMeshProUGUI>().text = "Press '" + keycode.ToString() + "' to cook";
    }

    // Update is called once per frame
    void Update()
    {
        //if(isPressButton)
        //{
        //    Time.timeScale = 0;
        //}

        //else
        //{
        //    Time.timeScale = 1;
        //}

        if (Vector2.Distance(this.gameObject.transform.position, player.transform.position) < distance)
        {
            if (doneCooking == false)
            {
                PopupMessage.SetActive(true);

                if (Input.GetKeyDown(keycode))
                {
                    isPressButton = !isPressButton;
                    //GameManager.instance.isPause = isPressButton;
                    CookingPanel.SetActive(isPressButton);
                }
            }

            else
            {
                doneCooking = false;
            }

        }

        else
        {
            PopupMessage.SetActive(false);
        }
    }
}
