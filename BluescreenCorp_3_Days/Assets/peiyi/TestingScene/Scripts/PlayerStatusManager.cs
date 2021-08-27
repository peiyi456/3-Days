using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatusManager : MonoBehaviour
{
    public static PlayerStatusManager instance;

    private void Awake()
    {
        instance = this;
    }

    public Slider PlayerHP;
    public Slider PlayerStamina;
    public Slider PlayerFood;
    public Slider PlayerWater;
}
