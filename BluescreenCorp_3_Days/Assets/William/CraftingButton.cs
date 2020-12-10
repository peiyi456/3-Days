using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingButton : MonoBehaviour
{
    public GameObject gettingComponent;
    public GameObject changeColour;
    void Start()
    {
        changeColour.gameObject.SetActive(false);
    }
    public void Trigger()
    {
        UILayering TriggerChangingCrafting = gettingComponent.GetComponent<UILayering>();
        TriggerChangingCrafting.isTriggerCrafting = true;
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
