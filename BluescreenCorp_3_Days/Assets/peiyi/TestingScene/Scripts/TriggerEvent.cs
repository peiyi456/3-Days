using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEvent : MonoBehaviour
{
    [SerializeField] bool interactToTrigger;
    [SerializeField] KeyCode keyCode;
    [SerializeField] bool doAction = false;
    [SerializeField] bool camp1, camp2;
    [SerializeField] GameObject ply;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(doAction)
        {
            if (Input.GetKey(keyCode))
            {
                doAction = false;
                Debug.Log("Put campsite at " + ply.transform.position);

            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if(interactToTrigger)
            {
                Debug.Log("11");
                //if (GameManager.instance.isPutCamp1 == false)
                //{
                    doAction = true;
                //}
            }

            else
            {
                //transfer to other position
            }
        }
    }


}
