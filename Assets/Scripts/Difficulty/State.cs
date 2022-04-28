using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State
{
    public enum Difficulty 
    {
        Easy, Medium, Hard, VeryHard
    }

    Difficulty difficultyName;
    protected GameObject dynamic;
    protected State nextState;
    protected int magnitude;

    public Difficulty DifficultyName { get => difficultyName; set => difficultyName = value; }

    public State(GameObject dynamicDifficulty)
    {
        dynamic = dynamicDifficulty;
    }

    public void Process()
    {
        dynamic.GetComponent<DynamicDifficulty>().MagnitudeOfOperations(magnitude);
    }

    public virtual State Progress()
    {
        Debug.Log("Progressed");
        return nextState;
    }

    public virtual State Regress()
    {
        return nextState;
    }
}
