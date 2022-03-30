using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Essence : MonoBehaviour
{
    Rigidbody rbody;

    float fallingSpeedNormal = 10f;
    float fallingSpeedEffected = 20f;

    void Awake()
    {
        rbody = gameObject.GetComponent<Rigidbody>();
        rbody.drag = 100 / fallingSpeedNormal;
    }

    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Projectile"))
        {
            other.gameObject.SetActive(false);
            rbody.drag = 100 / fallingSpeedEffected;
        }
    }
}   
