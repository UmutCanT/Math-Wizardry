using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Easy : State
{
    public Easy(DynamicDifficulty dynamicDifficulty) : base(dynamicDifficulty)
    {
        DifficultyName = Difficulty.Easy;
        ratioAdd = 40;
        ratioSubs = 40;
        ratioMulti = 10;
        ratioDivi = 10;
        ArrayValueChanger(ratioAdd, ratioSubs, ratioMulti, ratioDivi);
        normalPoint = 10;
        bonusPoint = 5;
        Debug.Log(DifficultyName.ToString());
    }

    public override State Progress()
    {
        nextState = new Medium(dynamic);
        return base.Progress();
    }

    public override State Regress()
    {
        nextState = this;
        return base.Regress();
    }

}
