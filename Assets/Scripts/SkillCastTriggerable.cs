using UnityEngine;

public class SkillCastTriggerable : MonoBehaviour
{
    Rigidbody projectile;
    Rigidbody clonedBullet;
    public float projectileForce = 2f;
    float aliveTime;

    public float AliveTime { get => aliveTime; set => aliveTime = value; }
    public Rigidbody Projectile { get => projectile; set => projectile = value; }

    void Start()
    {
        clonedBullet = Instantiate(projectile, transform.position, Quaternion.identity) as Rigidbody;
        clonedBullet.gameObject.SetActive(false);
    }

    public void TriggerCast()
    {
        clonedBullet.transform.position = transform.position;
        clonedBullet.velocity = Vector3.zero;           
        clonedBullet.gameObject.SetActive(true);    
        clonedBullet.AddForce(Vector3.up * projectileForce, ForceMode.Force);
    }
}
