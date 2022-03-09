using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class QuestionUI 
{
    const string ADD = "+";
    const string SUBS = "-";
    const string MULT = "*";
    const string DIV = "/";

    static string OperationDecider(MathOperations operations)
    {
        return operations switch
        {
            MathOperations.Addition => ADD,
            MathOperations.Substraction => SUBS,
            MathOperations.Multiplication => MULT,
            MathOperations.Division => DIV,
            _ => default,
        };
    }

    public static string AssignQuestion (MathQuestion question)
    {
        return string.Format("{0} {1} {2}", question.FirstNumber, OperationDecider(question.MathOperation), question.SecondNumber);
    }
}
