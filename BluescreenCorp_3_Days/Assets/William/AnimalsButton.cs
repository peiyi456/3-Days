using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalsButton : MonoBehaviour
{
    public GameObject gettingComponent;
    public GameObject changeColour;
    void Start()
    {
        changeColour.gameObject.SetActive(false);
    }
    public void Trigger()
    {
        UILayering TriggerChangingAnimals = gettingComponent.GetComponent<UILayering>();
        TriggerChangingAnimals.isTriggerAnimals = true;
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
