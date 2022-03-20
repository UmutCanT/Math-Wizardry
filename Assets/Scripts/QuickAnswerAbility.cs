using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (menuName = "Abilities/QuickAnswerAbility")]
public class QuickAnswerAbility : Ability
{
    public float aliveTime = 5f;
    public Vector3 spawnPos;

    SkillCastTriggerable skillCast;

    public override void Initialize(GameObject obj)
    {
        skillCast = obj.GetComponent<SkillCastTriggerable>();
        skillCast.Initialize();

        skillCast.SpawnPos = spawnPos;
        skillCast.AliveTime = aliveTime;
    }

    public override void TriggerAbility()
    {
        skillCast.TriggerCast();
    }
}
