using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterController2D : MonoBehaviour
{
    public static CharacterController2D instance;

    Rigidbody2D rb2D;
    [SerializeField] float speed = 2f;
    Vector2 motionVector;
    public Vector2 lastMotionVector;
    Animator animator;
    public bool moving;
    public bool stopMove;
    [SerializeField] AudioClip walkSound;

    private void Awake()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        stopMove = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 1)
        {
            if (GameManager.instance.isPause == false)
            {
                if (stopMove == false)
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
            }
            else
            {
                moving = false;
                animator.SetBool("Moving", moving);
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
        if (Time.timeScale == 1)
        {
            rb2D.velocity = motionVector * speed;
        }
        else
        {
            rb2D.velocity = Vector2.zero;
        }

        if(stopMove)
        {
            rb2D.velocity = Vector2.zero;
        }
    }

    public void PlayWalkSound()
    {
        if (GameManager.instance.isPause == false)
        {
            SoundManager.instance.soundEffect.PlayOneShot(walkSound);
        }
    }
}
