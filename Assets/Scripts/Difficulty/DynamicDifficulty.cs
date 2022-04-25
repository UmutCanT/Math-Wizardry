using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class DynamicDifficulty : MonoBehaviour
{
    State currentState;
    List<Choice> choices = new List<Choice>();
    int totalWeight;

    // Start is called before the first frame update
    void Awake()
    {
        choices.Add(new Choice(MathOperations.Addition, 3));
        choices.Add(new Choice(MathOperations.Substraction, 3));
        choices.Add(new Choice(MathOperations.Multiplication, 2));
        choices.Add(new Choice(MathOperations.Division, 2));

        foreach (Choice entry in choices)
        {
            totalWeight += entry.Weight;
        }        
    }

    public MathOperations OperationRandomizer()
    {
        int randomNumber = Random.Range(1, totalWeight + 1);
        Debug.Log("Random Number = " + randomNumber);
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
