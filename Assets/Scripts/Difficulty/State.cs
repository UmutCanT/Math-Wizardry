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
    protected DynamicDifficulty dynamic;
    protected State nextState;

    //Operation ratio according to difficulty
    protected int ratioAdd, ratioSubs, ratioMulti, ratioDivi;
    int[] operationRatios = new int[4];


    //Question Number Range according to difficulty
    protected int firstMin, firstMax, secondMin, secondMax;
    int[] questionNumberRange = new int[4];

    //Points according to difficulty
    protected int normalPoint;
    protected int bonusPoint;

    public Difficulty DifficultyName { get => difficultyName; set => difficultyName = value; }

    public State(DynamicDifficulty dynamicDifficulty)
    {
        dynamic = dynamicDifficulty;
    }

    public void Process()
    {
        dynamic.RatioChanger(operationRatios);
        dynamic.QuestionRangeChanger(questionNumberRange);
        dynamic.DifficultyPoints(normalPoint, bonusPoint);
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
    //Test
    protected void ArrayValueChanger2(int add, int subs, int multi, int divi)
    {
        questionNumberRange.SetValue(add, 0);
        questionNumberRange.SetValue(subs, 1);
        questionNumberRange.SetValue(multi, 2);
        questionNumberRange.SetValue(divi, 3);
    }
}
