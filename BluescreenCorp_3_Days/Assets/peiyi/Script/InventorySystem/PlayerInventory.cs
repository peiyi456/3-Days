using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public Inventory_ inventory_;

    [SerializeField] private UI_Inventory_ uiInventory_;

    private void Awake()
    {
        inventory_ = new Inventory_();
        uiInventory_.SetInventory_(inventory_);

    }
}
