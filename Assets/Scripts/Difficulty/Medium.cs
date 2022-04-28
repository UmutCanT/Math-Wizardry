using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Medium : State
{
    public Medium(GameObject dynamicDifficulty) : base(dynamicDifficulty)
    {
        DifficultyName = Difficulty.Medium;
        magnitude = 10;
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
