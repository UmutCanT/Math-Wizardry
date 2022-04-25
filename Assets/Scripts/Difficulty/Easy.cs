using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Easy : State
{
    public Easy(GameObject dynamicDifficulty) : base(dynamicDifficulty)
    {
        DifficultyName = Difficulty.Easy;
    }

    public override void Enter()
    {
        Debug.Log(DifficultyName);
        base.Enter();
    }

    public override void Update()
    {
        //if (CanSeePlayer())
        //{
        //    nextState = new Pursue(npc, agent, anim, player);
        //    stage = EVENT.EXIT;
        //}
        //else if (Random.Range(0, 100) < 10)
        //{
        //    nextState = new Patrol(npc, agent, anim, player);
        //    stage = EVENT.EXIT;
        //}
    }

    public override void Exit()
    {
       
        base.Exit();
    }
}
