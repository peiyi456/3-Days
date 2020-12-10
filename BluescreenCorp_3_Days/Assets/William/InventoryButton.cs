using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryButton : MonoBehaviour
{
    public GameObject gettingComponent;
    public GameObject changeColour;
    void Start()
    {
        changeColour.gameObject.SetActive(false);
    }
    public void Trigger()
    {
        UILayering TriggerChangingInventory = gettingComponent.GetComponent<UILayering>();
        TriggerChangingInventory.isTriggerInventory = true;
    }
    public void OnMouseEnter()
    {
        changeColour.gameObject.SetActive(true);
    }
    public void OnMouseExit()
    {
        changeColour.gameObject.SetActive(false);
    }
}
