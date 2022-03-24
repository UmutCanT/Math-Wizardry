using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillCastTriggerable : MonoBehaviour
{
    Rigidbody projectile;
    public float projectileForce = 250f;
    float aliveTime;

    public float AliveTime { get => aliveTime; set => aliveTime = value; }
    public Rigidbody Projectile { get => projectile; set => projectile = value; }

    public void TriggerCast()
    {
        Rigidbody clonedBullet = Instantiate(projectile, Vector3.zero, Quaternion.identity) as Rigidbody;
        clonedBullet.AddForce(Vector3.up * projectileForce);
    }
}
