using System.Linq;
using UnityEngine;

public class QuestionCreator
{
    private readonly DataHandler _instance = DataHandler.GetInstance();

    private const float MaxAmountOfChars = 100.0f;
    public void CreateNewQuestion(string statement, string correctAnswer, string[] wrongAnswers, string explanation, bool isReferenced, QuestionCategory category, QuestionDifficulty difficulty)
    {
        if (LengthIsValid(statement) &&
            LengthIsValid(correctAnswer) &&
            LengthIsValid(wrongAnswers) &&
            LengthIsValid(explanation))
        {
            var question = new Question(statement, correctAnswer, wrongAnswers, explanation, isReferenced, category, difficulty);

            _instance.AllValidQuestions.QuestionList.Add(question);
            ListOfAllQuestions.AddQuestion(question);

            Debug.Log("Great! Soon, you question will be checked if can be approved and you`ll be notified.");
        }
        else
        {
            Debug.LogError("Not possible create the question. Check if is correct.");
        }
    }

    private static bool LengthIsValid(string text)
    {
        return text.Length < MaxAmountOfChars;
    }

    private static bool LengthIsValid(string[] text)
    {
        return text.All(answer => answer.Length < MaxAmountOfChars);
    }
}