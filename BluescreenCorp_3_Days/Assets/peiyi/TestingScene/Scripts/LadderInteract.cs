using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LadderInteract : MonoBehaviour
{
    [Header("Check condition")]
    public bool Setup;
    public bool ClimbDown;
    public bool hasLadder;

    [SerializeField] float distance;

    [Header("Assign")]
    [SerializeField] float staminaUsed;
    //[SerializeField] GameObject player;
    [SerializeField] GameObject ProgressBar;
    [SerializeField] GameObject LadderPanel;
    [SerializeField] Item Ladder;
    //[SerializeField] Sprite sprite;
    [SerializeField] AudioClip aduioClip;
    [SerializeField] GameObject LadderGameObject;
    [SerializeField] GameObject climbUpPoint;
    [SerializeField] GameObject climbDownPoint;

    [Header("Keycode")]
    [SerializeField] KeyCode LadderKey;

    //SpriteRenderer thisSprite;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateText();

        if (Setup == false)
        {
            if (Vector2.Distance(GameManager.instance.player.transform.position, this.transform.position) < distance)
            {
                LadderPanel.SetActive(true);

                if (Input.GetKeyDown(LadderKey))
                {

                    if (GameManager.instance.inventoryContainer.slots.Find(x => x.item == Ladder) != null)
                    {
                        LadderGameObject.SetActive(true);
                        //ItemSlot itemSlot = GameManager.instance.inventoryContainer.slots.Find(x => x.item == Ladder);
                        PlayerStatusManager.instance.PlayerStamina.value -= 10;
                        GameManager.instance.inventoryContainer.RemoveItem(Ladder, 1);
                        Setup = true;
                    }
                }
            }

            else
            {
                LadderPanel.SetActive(false);
            }
        }

        else
        {
            if (ClimbDown == false)
            {
                if (Vector2.Distance(GameManager.instance.player.transform.position, climbUpPoint.transform.position) < distance)
                {
                    LadderPanel.SetActive(true);

                    if(Input.GetKeyDown(LadderKey))
                    {
                        GameManager.instance.player.transform.position = climbDownPoint.transform.position;
                        ClimbDown = true;
                    }

                }

                else
                {
                    LadderPanel.SetActive(false);
                }
            }

            else
            {
                if (Vector2.Distance(GameManager.instance.player.transform.position, climbDownPoint.transform.position) < distance)
                {
                    LadderPanel.SetActive(true);

                    if (Input.GetKeyDown(LadderKey))
                    {
                        GameManager.instance.player.transform.position = climbUpPoint.transform.position;
                        ClimbDown = false;
                    }

                }

                else
                {
                    LadderPanel.SetActive(false);
                }
            }
            
        }
    }

    void UpdateText()
    {
        if(Setup)
        {
            if (ClimbDown)
            {
                LadderPanel.GetComponentInChildren<TextMeshProUGUI>().text = "Press 'E' to climb up.";
            }
            else
            {
                LadderPanel.GetComponentInChildren<TextMeshProUGUI>().text = "Press 'E' to climb down.";
            }
        }

        else
        {
            if(GameManager.instance.inventoryContainer.slots.Find(x => x.item == Ladder) != null)
            {
                LadderPanel.GetComponentInChildren<TextMeshProUGUI>().text = "Press 'E' to set up a ladder.";
            }

            else
            {
                LadderPanel.GetComponentInChildren<TextMeshProUGUI>().text = "You can craft a ladder to climb down.";
            }
        }
    }
}
