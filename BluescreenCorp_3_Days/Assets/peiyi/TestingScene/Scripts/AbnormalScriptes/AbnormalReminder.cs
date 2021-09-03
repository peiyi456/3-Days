using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbnormalReminder : MonoBehaviour
{
    [SerializeField] string abnormalName;
    [SerializeField] Slider statusSliders;
    [SerializeField] int sliderValue;
    [SerializeField] Image abnormalReminder;
    [SerializeField] Image theObject;
    //[SerializeField] bool outReminder;

    // Start is called before the first frame update
    void Start()
    {
        //outReminder = false;
        //theObject = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (statusSliders.value < sliderValue)
        {
            if (theObject == null)
            {
                theObject = Instantiate(abnormalReminder, this.transform);
                theObject.name = abnormalName;
                //theObject.transform.parent = this.transform;
                //outReminder = true;
            }

        }
        else
        {
            if (theObject != null)
            {
                Destroy(theObject.gameObject);
            }
        }

    }
}
