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
        ArrayValueChanger(operationRatios, ratioAdd, ratioSubs, ratioMulti, ratioDivi);

        firstMin = 10;
        firstMax = 61;
        secondMin = 1;
        secondMax = 11;
        ArrayValueChanger(questionNumberRange, firstMin, firstMax, secondMin, secondMax);

        normalPoint = 10;
        bonusPoint = 5;
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
