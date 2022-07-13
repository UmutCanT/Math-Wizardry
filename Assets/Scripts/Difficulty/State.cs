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
    protected int[] operationRatios = new int[4];


    //Question Number Range according to difficulty
    protected int firstMin, firstMax, secondMin, secondMax;
    protected int[] questionNumberRange = new int[4];

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
        return nextState;
    }

    public virtual State Regress()
    {
        return nextState;
    }

    /// <summary>
    /// Desired array to change 
    /// </summary>
    /// <param name="array"> operationRatios or questionNumberRange </param>
    /// <param name="first"> ratioAdd or firstMin </param>
    /// <param name="second"> ratioSubs or firstMax </param>
    /// <param name="third"> ratioMulti or secondMin </param>
    /// <param name="fourth"> ratioDivi or secondMax </param>
    protected void ArrayValueChanger(int[] array, int first, int second, int third, int fourth)
    {
        array.SetValue(first, 0);
        array.SetValue(second, 1);
        array.SetValue(third, 2);
        array.SetValue(fourth, 3);
    }
}
