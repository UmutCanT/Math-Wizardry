using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Easy : State
{
    public Easy(GameObject dynamicDifficulty) : base(dynamicDifficulty)
    {
        DifficultyName = Difficulty.Easy;
        ratioAdd = 40;
        ratioSubs = 40;
        ratioMulti = 10;
        ratioDivi = 10;
        ArrayValueChanger(ratioAdd, ratioSubs, ratioMulti, ratioDivi);
        Debug.Log(DifficultyName.ToString());
    }

    public override State Progress()
    {
        nextState = new Medium(dynamic);
        return base.Progress();
    }
}
