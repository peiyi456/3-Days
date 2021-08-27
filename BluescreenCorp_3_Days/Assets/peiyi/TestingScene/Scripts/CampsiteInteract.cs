using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CampsiteInteract : MonoBehaviour
{
    GameObject player;
    [SerializeField] GameObject PopupMessage;
    [SerializeField] float distance;
    CanSleepOrNot sleepStatus;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
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
                    PopupMessage.SetActive(true);
                    if (Input.GetKeyDown(KeyCode.O))
                    {
                        Debug.Log("Sleep");
                        DayTimeManager.instance.sleepStatus = PlayerSleepingStatus.Sleep;
                    }
                }
            }
        }
        else
        {
            PopupMessage.SetActive(false);
        }
    }
}
