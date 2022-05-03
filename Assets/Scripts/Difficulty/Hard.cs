using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hard : State
{
    public Hard(DynamicDifficulty dynamicDifficulty) : base(dynamicDifficulty)
    {
        DifficultyName = Difficulty.Hard;
        ratioAdd = 25;
        ratioSubs = 25;
        ratioMulti = 25;
        ratioDivi = 25;
        ArrayValueChanger(ratioAdd, ratioSubs, ratioMulti, ratioDivi);
        normalPoint = 20;
        bonusPoint = 10;
        Debug.Log(DifficultyName.ToString());
    }

    public override State Progress()
    {
        nextState = new VeryHard(dynamic);
        return base.Progress();
    }

    public override State Regress()
    {
        nextState = new Medium(dynamic);
        return base.Regress();
    }
}
