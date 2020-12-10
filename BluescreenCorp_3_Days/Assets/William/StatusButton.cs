using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusButton : MonoBehaviour
{
    public GameObject gettingComponent;
    public GameObject changeColour;
    void Start()
    {
        changeColour.gameObject.SetActive(false);
    }
    public void Trigger()
    {
        UILayering TriggerChangingStatus = gettingComponent.GetComponent<UILayering>();
        TriggerChangingStatus.isTriggerStatus = true;
    }
    void OnMouseEnter()
    {
        changeColour.gameObject.SetActive(true);
    }
    void OnMouseExit()
    {
        changeColour.gameObject.SetActive(false);
    }
}
