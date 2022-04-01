using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Essence : MonoBehaviour
{
    Rigidbody rbody;

    float dragSpeedNormal = 10f;
    float dragSpeedEffected = 5f;

    public float DragSpeedNormal { get => dragSpeedNormal; set => dragSpeedNormal = value; }

    void Awake()
    {
        rbody = gameObject.GetComponent<Rigidbody>();
        rbody.drag = dragSpeedNormal;
    }

    void OnDisable()
    {
        rbody.velocity = Vector3.zero;
        rbody.drag = dragSpeedNormal;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Projectile"))
        {
            other.gameObject.SetActive(false);
            rbody.drag = dragSpeedEffected;
        }
    }   
}
