﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 80f;
    public float angle;
    float time, delayTime;
    Vector2 Dir;

    [SerializeField] bool inRange = false;

    [SerializeField] Transform seekTarget;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        time = Time.time;
        delayTime = 4.0f;
    }

    // Update is called once per frame
    void Update()
    {
        float Distance = Vector2.Distance(seekTarget.position, transform.position);

        if (Distance < 5f)
        {
            //Vector3 curPos = transform.position;
            //Vector3 newPos = seekTarget.position;
            Vector2 Dir = (seekTarget.position - transform.position).normalized;

            transform.LookAt(seekTarget.transform);
            rb.velocity = Dir * speed * Time.deltaTime;
            inRange = true;
        }

        else
        {
            inRange = false;
        }

        if (inRange == false)
        {
            if (time + delayTime < Time.time)
            {
                time = Time.time;
                angle = Random.Range(90, 270);
                transform.localRotation = Quaternion.Euler(0f, angle, 0f);

                speed = Random.Range((int)80, (int)100);
            }
            Vector2 rbVel = ConvertVelocityToVector3(speed, angle) * Time.deltaTime;
            rb.velocity = rbVel;
        }
    }

    Vector2 ConvertVelocityToVector3(float velocity, float direction)
    {
        float x = Mathf.Sin(direction * Mathf.Deg2Rad);
        //float z = Mathf.Cos(direction * Mathf.Deg2Rad);

        Vector2 RBVel = new Vector3(x, 0) * velocity;
        return RBVel;
    }
}
