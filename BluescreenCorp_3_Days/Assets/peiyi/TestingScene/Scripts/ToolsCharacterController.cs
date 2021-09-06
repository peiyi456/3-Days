using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToolsCharacterController : MonoBehaviour
{
    public static ToolsCharacterController instance;

    CharacterController2D character;
    Rigidbody2D rgbd2d;
    [SerializeField] float offsetDistance = 1f;
    [SerializeField] float sizeOfInteractableArea = 1.2f;
    //[SerializeField] Slider stamina;
    public bool ableToInteract;

    private void Awake()
    {
        character = GetComponent<CharacterController2D>();
        rgbd2d = GetComponent<Rigidbody2D>();
        instance = this;
    }

    private void Update()
    {
        //if (GameManager.instance.isPause == false)
        //{
        if (ableToInteract)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                UseTool();
                ableToInteract = false;
                PlayerStatusManager.instance.PlayerStamina.value -= 10f;
            }
        }
        //}
    }

    private void UseTool()
    {
        Vector2 position = rgbd2d.position + character.lastMotionVector * offsetDistance;

        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, sizeOfInteractableArea);

        foreach(Collider2D c in colliders)
        {
            ToolHit hit = c.GetComponent<ToolHit>();
            if(hit != null)
            {
                hit.Hit();
                break;
            }
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<TreeInteract>() != null)
        {
            TreeInteract checking = collision.gameObject.GetComponent<TreeInteract>();
            Debug.Log("Hello");
            if (checking != null)
            {
                ableToInteract = checking.ableToInteract;

            }

            else
            {
                ableToInteract = false;
            }
        }
    }
}
