using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    QuestionCreator questionCreator = new QuestionCreator();
    MathQuestion mathQuestion;
    List<MathQuestion> questions = new List<MathQuestion>();

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(AddingAndChecking), 1f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CheckResults()
    {
        foreach (var question in questions)
        {
            Debug.Log(question.FirstNumber + " " + question.MathOperation + " " + question.SecondNumber + "=" + question.CorrectAnswer);
        }
    }

    void AddingAndChecking()
    {
        questions.Add(questionCreator.QuestionGenerator(mathQuestion));
        CheckResults();
    }
}
