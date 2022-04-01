using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Essence : MonoBehaviour
{
    Rigidbody rbody;
    Statuses status;

    float dragSpeedNormal = 10f;
    float dragSpeedEffected = 5f;

    public float DragSpeedNormal { get => dragSpeedNormal; set => dragSpeedNormal = value; }
    public Statuses Status { get => status; set => status = value; }

    void Awake()
    {
        status = Statuses.normal;
        rbody = gameObject.GetComponent<Rigidbody>();
        rbody.drag = dragSpeedNormal;
    }

    void OnDisable()
    {
        status = Statuses.normal;
        rbody.velocity = Vector3.zero;
        rbody.drag = dragSpeedNormal;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Projectile"))
        {
            other.gameObject.SetActive(false);
            rbody.drag = dragSpeedEffected;
            status = Statuses.effected;
        }
    }   
}

public enum Statuses
{
    normal,
    effected
}
