public class Question
{
    #region InternallyDefined

    public int ID { get; private set; }

    public float NumberOfTimesAnsweredCorrectly { get; private set; }
    public float NumberOfTimesAnswered { get; private set; }

    public float PercentageOfCorrectAnswers
    {
        get => NumberOfTimesAnsweredCorrectly * 100 / NumberOfTimesAnswered;
    }

    #endregion

    #region UserDefined

    public string Statement { get; private set; }
    public string CorrectAnswer { get; private set; }
    public string[] WrongAnswers { get; private set; }
    public string Explanation { get; private set; }

    public string Reference { get; private set; }
    public bool IsReferenced { get; private set; }

    public QuestionCategory Category { get; private set; }
    public QuestionDifficulty Difficulty { get; private set; }

    #endregion

    public Question(string statement, string correctAnswer, string[] wrongAnswers, string explanation, bool isReferenced, QuestionCategory category, QuestionDifficulty difficulty)
    {
        Statement = statement;
        CorrectAnswer = correctAnswer;
        WrongAnswers = wrongAnswers;
        Explanation = explanation;
        IsReferenced = isReferenced;
        Category = category;
        Difficulty = difficulty;

        ID = GenerateID();
    }

    private int GenerateID()
    {
        if (ListOfAllQuestions.GetCount() == 0)
        {
            return 0;
        }

        var lastIndex = ListOfAllQuestions.GetCount() - 1;
        var lastQuestion = ListOfAllQuestions.FindQuestionByIndex(lastIndex);
        return lastQuestion.ID + 1;
    }

    public void ChangeDifficulty(QuestionDifficulty difficulty)
    {
        Difficulty = difficulty;
    }
}