using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Abilities/QuickAnswerAbility")]
public class QuickAnswerAbility : Ability
{
    public float aliveTime = 5f;
    public Rigidbody projectile;
    SkillCastTriggerable skillCast;

    public override void Initialize(GameObject obj)
    {
        skillCast = obj.GetComponent<SkillCastTriggerable>();
        skillCast.Projectile = projectile;       
    }

    public override void TriggerAbility()
    {
        skillCast.TriggerCast();
    }
}
