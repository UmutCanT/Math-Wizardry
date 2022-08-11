using System.Collections.Generic;
using UnityEngine;

public class DynamicDifficulty : MonoBehaviour
{
    [SerializeField]Score score;
    List<Choice> choices = new List<Choice>();
    int totalWeight;
    //Addition first/second, Substraction first/second Division first [0]:min [1]:max
    //Multiplication first/second, Division second [2]:min [3]:max
    int[] questionNumberRange = new int[4];

    public void DifficultyPoints(int point, int bonus)
    {
        score.Point = point;
        score.BonusPoint = bonus;
    }

    public void RatioChanger(int[] ratios)
    {
        for (int i = 0; i < choices.Count; i++)
        {
            choices[i].Weight = ratios[i];           
        }
    }

    public void QuestionRangeChanger(int[] newRange)
    {
        for (int i = 0; i < questionNumberRange.Length; i++)
        {
            questionNumberRange[i] = newRange[i];
        }
    }

    public void OperationRandomizerCreator()
    {
        choices.Add(new Choice(MathOperations.Addition, 25));
        choices.Add(new Choice(MathOperations.Substraction, 25));
        choices.Add(new Choice(MathOperations.Multiplication, 25));
        choices.Add(new Choice(MathOperations.Division, 25));

        foreach (Choice entry in choices)
        {
            totalWeight += entry.Weight;
        }
    }

    public MathOperations OperationRandomizer()
    {
        int randomNumber = Random.Range(1, totalWeight + 1);
        int pos = 0;
        for (int i = 0; i < choices.Count; i++)
        {
            if (randomNumber <= choices[i].Weight + pos)
            {
                return choices[i].ChoiceName;
            }
            pos += choices[i].Weight;
        }
        return MathOperations.Addition;
    }

    public int QuestionNumberRange(bool choosenRange)
    {
        if (choosenRange)
        {
            return Random.Range(questionNumberRange[0], questionNumberRange[1]);
        }else
            return Random.Range(questionNumberRange[2], questionNumberRange[3]);
    }
}
public class Choice
{
    MathOperations choiceName;
    int weight;

    public Choice(MathOperations newChoiceName, int newChoiceWeight)
    {
        choiceName = newChoiceName;
        weight = newChoiceWeight;
    }

    public int Weight { get => weight; set => weight = value; }
    public MathOperations ChoiceName { get => choiceName; set => choiceName = value; }
}
