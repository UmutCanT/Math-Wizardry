using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Essence : MonoBehaviour
{
    Rigidbody rbody;
    Statuses status;
    Vector3 startingPosition;

    //Lower is faster 
    float dragSpeedNormal = 10f;
    readonly float dragSpeedEffected = 2f;
    readonly float acceleration = 0.15f;
    float glidingSpeedMin = 5f;
    float glidingSpeedMax = 10f;

    public float DragSpeedNormal { get => dragSpeedNormal; set => dragSpeedNormal = value; }
    public Statuses Status { get => status; set => status = value; }

    void Awake()
    {
        startingPosition = transform.position;
        status = Statuses.normal;
        rbody = gameObject.GetComponent<Rigidbody>();
        dragSpeedNormal = glidingSpeedMax;
    }
    void Start()
    {       
        rbody.drag = dragSpeedNormal;
    }

    void OnEnable()
    {
        transform.position = startingPosition;
    }

    void OnDisable()
    {       
        status = Statuses.normal;
        rbody.velocity = Vector3.zero;
        rbody.drag = DragSpeed();
        Debug.Log(rbody.drag);
    }

    float DragSpeed()
    {
        if(dragSpeedNormal > glidingSpeedMin)
        {
            dragSpeedNormal -= acceleration;
        }
        return dragSpeedNormal;
    } 

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Projectile"))
        {
            other.gameObject.SetActive(false);
            rbody.drag = dragSpeedNormal/dragSpeedEffected;
            status = Statuses.effected;
        }
    }   
}

public enum Statuses
{
    normal,
    effected
}
