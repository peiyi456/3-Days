using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject objPlayer;
    public Vector2 followObject;
    private Vector2 maxObject;
    private Rigidbody2D rbPlayer;
    public float speed = 9.5f;
    bool activeFollowX;
    bool activeFollowY;
    float positionMinX = -58.0f;
    float positionMaxX = 19.9f;
    float positionMaxY = 48.0f;
    float positionMinY = -25.0f;

    void Start()
    {
        activeFollowX = true;
        activeFollowY = true;
        rbPlayer = objPlayer.GetComponent<Rigidbody2D>();
    }
    void limitRange()
    {
        if (objPlayer.transform.position.x < positionMinX || objPlayer.transform.position.x > positionMaxX)
        {
            activeFollowX = false;
        }
        else
        {
            activeFollowX = true;
        }
        if (objPlayer.transform.position.y < positionMinY || objPlayer.transform.position.y > positionMaxY)
        {
            activeFollowY = false;
        }
        else
        {
            activeFollowY = true;
        }
    }
    void LateUpdate()
    {
        limitRange();
        Debug.Log(positionMinX);
        Debug.Log(positionMaxX);
        Debug.Log(objPlayer.transform.position.x);
        Debug.Log(objPlayer.transform.position.y);

    }
    void Update()
    {
        
    }
    void FixedUpdate()
    {
        
        {
            Vector2 Follow = objPlayer.transform.position;
            ///Check the difference of the moving player
            float differenceX = Vector2.Distance(Vector2.right * transform.position.x, Vector2.right * Follow.x);
            float differenceY = Vector2.Distance(Vector2.up * transform.position.y, Vector2.up * Follow.y);

            ///If difference more than ???, follow player
            Vector3 newPosition = transform.position;
            if (activeFollowX == true)
            {
                if (Mathf.Abs(differenceX) >= maxObject.x)
                {
                    newPosition.x = Follow.x;
                }
            }
            if (activeFollowY == true)
            {
                if (Mathf.Abs(differenceY) >= maxObject.y)
                {
                    newPosition.y = Follow.y;
                }
            }

            ///Rigidbody also follow character speed
            ///Use trus, false statement
            /// ? = true, : = false
            /// if     rbplayer.velocity > speed, speed = rbplayer.velocity;
            /// else   rbplayer.velpcity = speed;
            float moveSpeed = rbPlayer.velocity.magnitude > speed ? rbPlayer.velocity.magnitude : speed;

            ///Camera movement same as player
            transform.position = Vector3.MoveTowards(transform.position, newPosition, moveSpeed * Time.deltaTime);
            //transform.position = new Vector3(Mathf.Clamp(transform.position.x, -63.3f, 24.2f), Mathf.Clamp(transform.position.y, 48.6f, -25.2f), transform.position.z);
        }
    }


}
