using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalsButton : MonoBehaviour
{
    public GameObject gettingComponent;
    void Trigger()
    {
        if(Input.GetMouseButtonDown(0))
        {
            UILayering TriggerChangingAnimals = gettingComponent.GetComponent<UILayering>();
            TriggerChangingAnimals.isTriggerAnimals = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        Trigger();
    }
}
