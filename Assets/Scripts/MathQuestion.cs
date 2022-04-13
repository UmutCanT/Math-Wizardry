public struct MathQuestion
{
    int firstNumber;
    int secondNumber;
    int correctAnswer;
    MathOperations mathOperation;
    int[] answers;

    public int FirstNumber { get => firstNumber; set => firstNumber = value; }
    public int SecondNumber { get => secondNumber; set => secondNumber = value; }
    public int CorrectAnswer { get => correctAnswer; set => correctAnswer = value; }
    public MathOperations MathOperation { get => mathOperation; set => mathOperation = value; }
    public int[] Answers { get => answers; set => answers = value; }
}

public enum MathOperations
{
    Addition,
    Substraction,
    Multiplication,
    Division
}
