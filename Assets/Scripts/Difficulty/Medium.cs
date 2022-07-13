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
        ArrayValueChanger(operationRatios, ratioAdd, ratioSubs, ratioMulti, ratioDivi);

        firstMin = 20;
        firstMax = 201;
        secondMin = 1;
        secondMax = 21;
        ArrayValueChanger(questionNumberRange, firstMin, firstMax, secondMin, secondMax);

        normalPoint = 20;
        bonusPoint = 10;
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
