using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusButton : MonoBehaviour
{
    public GameObject gettingComponent;
    void Trigger()
    {
        if (Input.GetMouseButtonDown(0))
        {
            UILayering TriggerChangingStatus = gettingComponent.GetComponent<UILayering>();
            TriggerChangingStatus.isTriggerStatus = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        Trigger();
    }
}
