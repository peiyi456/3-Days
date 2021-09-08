using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TriggerEvent : MonoBehaviour
{
    [SerializeField] bool interactToTrigger;
    [SerializeField] KeyCode keyCode;
    [SerializeField] bool doAction = false;
    [SerializeField] bool camp1/*, camp2*/;
    [SerializeField] GameObject player;
    [SerializeField] GameObject spawnPrefab;
    [SerializeField] Sprite campsiteSprite;

    // Start is called before the first frame update
    void Start()
    {
        player = GameManager.instance.player;
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
                    if (camp1 == false)
                    {
                        doAction = false;
                        Debug.Log("Put campsite at " + player.transform.position);
                        spawnPrefab.GetComponent<SpriteRenderer>().sprite = campsiteSprite;
                        GameObject campsite = Instantiate(spawnPrefab, new Vector2(player.transform.position.x, player.transform.position.y - 0.5f), Quaternion.identity);
                        GameManager.instance.hasCampsite = false;
                        camp1 = true;
                        GameManager.instance.CampSetupNumber += 1;
                    }
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            //CampFireInteract.isNearCampFire = true;
            doAction = true;
            if (camp1 == false)
            {
                GameManager.instance.TextReminder.GetComponentInChildren<TextMeshProUGUI>().text = "It seems like it is able to put a campsite here. You can craft a campsite and press 'P' to put it here.";
                GameManager.instance.TextReminder.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            //CampFireInteract.isNearCampFire = false;
            //if (camp1 == false)
            //{
            GameManager.instance.TextReminder.GetComponentInChildren<TextMeshProUGUI>().text = "It seems like it is able to put a campsite here. You can craft a campsite and press 'P' to put it here.";
                GameManager.instance.TextReminder.SetActive(false);
            //}
        }
    }
}
