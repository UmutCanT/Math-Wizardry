using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medium : State
{
    public Medium(GameObject dynamicDifficulty) : base(dynamicDifficulty)
    {
        DifficultyName = Difficulty.Medium;
        ratioAdd = 30;
        ratioSubs = 30;
        ratioMulti = 20;
        ratioDivi = 20;
        ArrayValueChanger(ratioAdd, ratioSubs, ratioMulti, ratioDivi);
        Debug.Log(DifficultyName.ToString());
    }

    public override State Progress()
    {
        nextState = new Medium(dynamic);
        return base.Progress();
    }

    public override State Regress()
    {
        nextState = new Easy(dynamic);
        return base.Regress();
    }
}
