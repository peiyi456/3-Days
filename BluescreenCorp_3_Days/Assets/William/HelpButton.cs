using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpButton : MonoBehaviour
{
    public GameObject gettingComponent;
    public GameObject changeColour;
    void Start()
    {
        changeColour.gameObject.SetActive(false);
    }
    public void Trigger()
    {
        UILayering TriggerChangingInformation = gettingComponent.GetComponent<UILayering>();
        TriggerChangingInformation.isTriggerInformation = true;
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
