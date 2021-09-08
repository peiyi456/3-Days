using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchFunction : MonoBehaviour
{
    [SerializeField] GameObject Torch;
    [SerializeField] bool isNight;
    [SerializeField] bool isUse;
    [SerializeField] bool canDestroy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if(DayTimeManager.instance.hours > 19 )
    }
}
