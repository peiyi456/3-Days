using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEvent : MonoBehaviour
{
    [SerializeField] bool interactToTrigger;
    [SerializeField] KeyCode keyCode;
    [SerializeField] bool doAction = false;
    [SerializeField] bool camp1, camp2;
    [SerializeField] GameObject player;
    [SerializeField] GameObject spawnPrefab;
    [SerializeField] Sprite campsiteSprite;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(doAction)
        {
            if (Input.GetKey(keyCode))
            {
                if (GameManager.instance.hasCampsite == true)
                {
                    doAction = false;
                    Debug.Log("Put campsite at " + player.transform.position);
                    spawnPrefab.GetComponent<SpriteRenderer>().sprite = campsiteSprite;
                    GameObject campsite = Instantiate(spawnPrefab, new Vector2(player.transform.position.x, player.transform.position.y - 0.5f), Quaternion.identity);
                    GameManager.instance.hasCampsite = false;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            //if(interactToTrigger)
            //{
                //Debug.Log("11");
                //if (GameManager.instance.isPutCamp1 == false)
                //{
                    doAction = true;
                //}
            //}

           // else
            //{
                //transfer to other position
            //}
        }
    }


}
