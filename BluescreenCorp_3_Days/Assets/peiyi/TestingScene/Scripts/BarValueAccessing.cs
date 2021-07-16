using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BarValueAccessing : MonoBehaviour
{
    [SerializeField] Slider thisBar;
    [SerializeField] Slider targetBar;

    // Start is called before the first frame update
    void Awake()
    {
        ////thisBar = GetComponent<Slider>();
        //thisBar.maxValue = targetBar.maxValue;
        //thisBar.minValue = targetBar.minValue;
        //Debug.Log("maxVaThis: " + thisBar.maxValue);
        //Debug.Log("maxVaTar: " + targetBar.maxValue);
    }

    private void Start()
    {
        thisBar = thisBar.GetComponent<Slider>();
        targetBar = targetBar.GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        thisBar.maxValue = targetBar.maxValue;
        thisBar.minValue = targetBar.minValue;
        thisBar.value = targetBar.value;
    }
}
