using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillCastTriggerable : MonoBehaviour
{
    public Rigidbody projectile;
    public Transform spawnPos;
    public float projectileForce = 250f;
    float aliveTime;

    public Transform SpawnPos { get => spawnPos; set => spawnPos = value; }
    public float AliveTime { get => aliveTime; set => aliveTime = value; }   

    public void TriggerCast()
    {
        Rigidbody clonedBullet = Instantiate(projectile, spawnPos.position, transform.rotation) as Rigidbody;
        clonedBullet.AddForce(spawnPos.transform.up * projectileForce);
    }
}
