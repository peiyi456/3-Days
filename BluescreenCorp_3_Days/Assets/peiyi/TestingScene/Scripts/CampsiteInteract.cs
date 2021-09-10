using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CampsiteInteract : MonoBehaviour
{
    GameObject player;
    [SerializeField] GameObject PopupMessage;
    [SerializeField] float distance;
    [SerializeField] KeyCode sleepKey;
    CanSleepOrNot sleepStatus;

    [SerializeField] GameObject TextReminder;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        //PopupMessage.GetComponentInChildren<TextMeshProUGUI>().text = "Do you want to sleep? \nPress '" + sleepKey + "' to sleep.";
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(this.gameObject.transform.position, player.transform.position) < distance)
        {
            if (DayTimeManager.instance.canSleep == CanSleepOrNot.CanSleep)
            {
                if (DayTimeManager.instance.sleepStatus == PlayerSleepingStatus.Wake)
                {
                    TextReminder.GetComponentInChildren<TextMeshProUGUI>().text = "Do you want to sleep? Press '" + sleepKey + "' to sleep.";
                    //PopupMessage.SetActive(true);
                    TextReminder.SetActive(true);
                    if (Input.GetKeyDown(sleepKey))
                    {
                        Debug.Log("Sleep");
                        DayTimeManager.instance.sleepStatus = PlayerSleepingStatus.Sleep;
                    }
                }
            }
        }
        else
        {
            TextReminder.SetActive(false);
        }
    }
}
