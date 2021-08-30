using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Wandering : MonoBehaviour
{
    NavMeshAgent navMesh;
    public Transform WanderingArea;
    Vector3 Destination;


    bool isArrive = true;

    // Start is called before the first frame update
    void Start()
    {
        navMesh = GetComponent<NavMeshAgent>();
        navMesh.updateRotation = false;
        navMesh.updateUpAxis = false;
        //navMesh.SetDestination(WanderingArea.position);
    }

    private void FixedUpdate()
    {
        //if(isArrive)
        //{

        //}
        //else
        //{

        //}
    }

    // Update is called once per frame
    void Update()
    {
        if(isArrive)
        {
            Vector2 randomInCiecle = new Vector2(WanderingArea.position.x, WanderingArea.position.y) + Random.insideUnitCircle * 10f;
            Destination = new Vector3(randomInCiecle.x, randomInCiecle.y, 0f);

            isArrive = false;
            navMesh.SetDestination(Destination);

            StartCoroutine(WanderingFunc());
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
    }

    IEnumerator WanderingFunc()
    {
        float dist = Vector3.Distance(this.transform.position, Destination);

        while(dist >= 0.1f)
        {
            dist = Vector3.Distance(this.transform.position, Destination);
            yield return null;
        }
        yield return new WaitForSeconds(3f);
        isArrive = true;
    }


}
