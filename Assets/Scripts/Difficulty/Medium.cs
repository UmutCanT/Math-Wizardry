using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medium : State
{
    public Medium(DynamicDifficulty dynamicDifficulty) : base(dynamicDifficulty)
    {
        DifficultyName = Difficulty.Medium;
        ratioAdd = 30;
        ratioSubs = 30;
        ratioMulti = 20;
        ratioDivi = 20;
        ArrayValueChanger(ratioAdd, ratioSubs, ratioMulti, ratioDivi);

        firstMin = 20;
        firstMax = 201;
        secondMin = 1;
        secondMax = 21;
        ArrayValueChanger2(firstMin, firstMax, secondMin, secondMax);

        normalPoint = 15;
        bonusPoint = 8;
        Debug.Log(DifficultyName.ToString());
    }

    public override State Progress()
    {
        nextState = new Hard(dynamic);
        return base.Progress();
    }

    public override State Regress()
    {
        nextState = new Easy(dynamic);
        return base.Regress();
    }
}
