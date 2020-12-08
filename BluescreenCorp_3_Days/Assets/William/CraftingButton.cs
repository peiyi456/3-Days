using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingButton : MonoBehaviour
{
    public GameObject gettingComponent;
    void Trigger()
    {
        if (Input.GetMouseButtonDown(0))
        {
            UILayering TriggerChangingCrafting = gettingComponent.GetComponent<UILayering>();
            TriggerChangingCrafting.isTriggerCrafting = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        Trigger();
    }
}
