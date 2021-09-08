using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Wandering : MonoBehaviour
{
    Animator animator;

    NavMeshAgent navMesh;
    public Transform WanderingArea;
    Vector3 Destination;


    public bool isArrive = true;
    public bool isSeek = false;

    public GameObject player;
    public float radius;
    public float distanceBtwPlayer;
    float oriSpeed;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        player = GameManager.instance.player;
        navMesh = GetComponent<NavMeshAgent>();
        navMesh.updateRotation = false;
        navMesh.updateUpAxis = false;
        WanderingArea = GetComponentInParent<AnimalSpawnerScript>().WanderingArea;
        radius = GetComponentInParent<AnimalSpawnerScript>().Radius;
        distanceBtwPlayer = GetComponentInParent<AnimalSpawnerScript>().seekingPlayerRadius;

        oriSpeed = navMesh.speed;
    }

    // Update is called once per frame
    void Update()
    {
        //if (GameManager.instance.isPause == false)
        //{
            if (Vector2.Distance(this.transform.position, player.transform.position) <= distanceBtwPlayer)
            {
                isSeek = true;
            }

            else
            {
                isSeek = false;

            }

            if (isSeek == false)
            {
                if (isArrive)
                {
                    Vector2 randomInCiecle = new Vector2(WanderingArea.position.x, WanderingArea.position.y) + Random.insideUnitCircle * radius;
                    Destination = new Vector3(randomInCiecle.x, randomInCiecle.y, 0f);

                    isArrive = false;

                    navMesh.speed = oriSpeed;

                    navMesh.SetDestination(Destination);

                    StartCoroutine(WanderingFunc());
                }
            }

            else
            {
                isArrive = true;
                navMesh.speed = oriSpeed + 3;
                Destination = player.transform.position;
                navMesh.SetDestination(new Vector3(Destination.x, Destination.y, transform.position.z));
            }

            float x = Destination.x - transform.position.x;

            if (x >= 0)
            {
                //transform.localScale = new Vector3(0.4151863f, 0.4151863f, 0.4151863f);
                GetComponent<SpriteRenderer>().flipX = false;
                GetComponent<SpriteRenderer>().flipY = false;
            }

            else
            {
                GetComponent<SpriteRenderer>().flipX = true;
                GetComponent<SpriteRenderer>().flipY = false;
            }

        //}
    }

    private void OnEnable()
    {
        isArrive = true;
        isSeek = false;
    }

    IEnumerator WanderingFunc()
    {

        float dist = Vector3.Distance(this.transform.position, Destination);

        while (dist >= 0.1f)
        {
            dist = Vector3.Distance(this.transform.position, Destination);
            yield return null;
        }

        animator.SetBool("IsIdle", true);
        yield return new WaitForSeconds(3f);
        isArrive = true;
        animator.SetBool("IsIdle", false);

    }


}
