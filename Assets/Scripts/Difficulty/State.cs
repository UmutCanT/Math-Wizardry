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

    //Operation ratio according to difficulty
    protected int ratioAdd, ratioSubs, ratioMulti, ratioDivi;
    int[] operationRatios = new int[4];

    public Difficulty DifficultyName { get => difficultyName; set => difficultyName = value; }

    public State(GameObject dynamicDifficulty)
    {
        dynamic = dynamicDifficulty;
    }

    public void Process()
    {
        dynamic.GetComponent<DynamicDifficulty>().RatioChanger(operationRatios);
    }

    public virtual State Progress()
    {
        Debug.Log("Progressed");
        return nextState;
    }

    public virtual State Regress()
    {
        Debug.Log("Regressed");
        return nextState;
    }

    protected void ArrayValueChanger(int add, int subs, int multi, int divi)
    {
        operationRatios.SetValue(add, 0);
        operationRatios.SetValue(subs, 1);
        operationRatios.SetValue(multi, 2);
        operationRatios.SetValue(divi, 3);
    }
}
