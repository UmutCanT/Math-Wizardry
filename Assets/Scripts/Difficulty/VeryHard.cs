using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VeryHard : State
{
    public VeryHard(DynamicDifficulty dynamicDifficulty) : base(dynamicDifficulty)
    {
        DifficultyName = Difficulty.VeryHard;
        ratioAdd = 15;
        ratioSubs = 15;
        ratioMulti = 35;
        ratioDivi = 35;
        ArrayValueChanger(ratioAdd, ratioSubs, ratioMulti, ratioDivi);
        normalPoint = 30;
        bonusPoint = 15;
        Debug.Log(DifficultyName.ToString());
    }

    public override State Progress()
    {
        nextState = this;
        return base.Progress();
    }

    public override State Regress()
    {
        nextState = new Hard(dynamic);
        return base.Regress();
    }
}
