using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Essence : MonoBehaviour
{
    Rigidbody rbody;
    Statuses status;

    float fallingSpeedNormal = 10f;
    float fallingSpeedEffected = 20f;

    public Statuses Status { get => status; set => status = value; }

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
            status = Statuses.effected;
            rbody.drag = 100 / fallingSpeedEffected;
        }
    }
}

public enum Statuses
{
    normal,
    effected,
    bonus
}
