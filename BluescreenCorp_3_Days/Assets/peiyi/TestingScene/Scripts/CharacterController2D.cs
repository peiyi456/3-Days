using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterController2D : MonoBehaviour
{
    Rigidbody2D rb2D;
    [SerializeField] float speed = 2f;
    Vector2 motionVector;
    public Vector2 lastMotionVector;
    Animator animator;
    public bool moving;
    [SerializeField] AudioClip walkSound;

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isPause == false)
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");

            motionVector = new Vector2(
                horizontal,
                vertical
                );

            animator.SetFloat("Horizontal", horizontal);
            animator.SetFloat("Vertical", vertical);

            moving = horizontal != 0 || vertical != 0;
            animator.SetBool("Moving", moving);

            if (horizontal != 0 || vertical != 0)
            {
                lastMotionVector = new Vector2(
                    horizontal,
                    vertical
                    ).normalized;

                animator.SetFloat("LastHorizontal", horizontal);
                animator.SetFloat("LastVertical", vertical);
            }
        }
        else
        {
            moving = false;
            animator.SetBool("Moving", moving);
        }
    }

    private void FixedUpdate()
    {
        
            Move();
        
    }

    private void Move()
    {
        if (GameManager.instance.isPause == false)
        {
            rb2D.velocity = motionVector * speed;
        }
        else
        {
            rb2D.velocity = Vector2.zero;
        }
    }

    public void PlayWalkSound()
    {
        GameManager.instance.soundEffect.PlayOneShot(walkSound);
    }
}
