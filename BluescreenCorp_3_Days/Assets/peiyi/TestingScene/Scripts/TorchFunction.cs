using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchFunction : MonoBehaviour
{

    [SerializeField] GameObject Torch;
    public static bool isNight;
    public static bool isUse;
    [SerializeField] bool canDestroy;
    [SerializeField] KeyCode key;


    // Start is called before the first frame update
    void Start()
    {
        isUse = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(DayTimeManager.instance.hours > 18)
        {
            isNight = true;
        }

        else if (DayTimeManager.instance.hours >= 0 && DayTimeManager.instance.hours < 5 )
        {
            isNight = true;
        }

        else
        {
            isNight = false;

            if(canDestroy == true)
            {
                GameManager.instance.hasTorch = false;
                Torch.SetActive(false);
                canDestroy = false;
            }
        }

        if(isNight)
        {
            if(Input.GetKeyDown(key))
            {
                if (GameManager.instance.hasTorch)
                {
                    isUse = !isUse;
                    Torch.SetActive(isUse);
                    canDestroy = true;
                }
            }
        }

    }
}
