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
        questions.Add(questionCreator.QuestionGenerator(mathQuestion));
        Debug.Log(questions[0].FirstNumber + " " + questions[0].MathOperation + " " + questions[0].SecondNumber + "=" + questions[0].CorrectAnswer);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
