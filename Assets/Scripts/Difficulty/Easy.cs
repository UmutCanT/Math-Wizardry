using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Easy : State
{
    public Easy(GameObject dynamicDifficulty) : base(dynamicDifficulty)
    {
        DifficultyName = Difficulty.Easy;
        magnitude = 5;
        Debug.Log(DifficultyName.ToString());
    }

    public override State Progress()
    {
        nextState = new Medium(dynamic);
        return base.Progress();
    }
}
