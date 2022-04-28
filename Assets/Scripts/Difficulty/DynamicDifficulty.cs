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
        OperationRandomizerCreator();
        foreach (Choice entry in choices)
        {
            Debug.Log(entry.ChoiceName.ToString() + " " + entry.Weight);
        }
        currentState = new Easy(this.gameObject);
        Answering.OnProgress += UpdateDifficulty;
        currentState.Process();
    }

    void UpdateDifficulty()
    {
        currentState = currentState.Progress();
        currentState.Process();
    }

    public void MagnitudeOfOperations(int magnitude)
    {
        foreach (Choice entry in choices)
        {
            entry.Weight = magnitude;
            Debug.Log(entry.ChoiceName.ToString() + " " + entry.Weight);
        }
    }

    void OperationRandomizerCreator()
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
        //Debug.Log("Random Number = " + randomNumber);
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
