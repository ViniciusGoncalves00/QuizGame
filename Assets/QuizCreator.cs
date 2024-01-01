using System.Collections.Generic;

public class QuizCreator
{
    private List<Question> _selectedQuestions = new List<Question>();
    private List<Question> _tempList = new List<Question>();
    private Queue<Question> _tempQueue = new Queue<Question>();

    public Queue<Question> GenerateQuiz(IQuestionContainer questionContainer, int questionsAmount, bool? scientificallyReferenced, QuestionCategory? category, QuestionDifficulty? difficulty)
    {
        _selectedQuestions.Clear();
        _tempList.Clear();
        _tempQueue.Clear();

        var questionList = questionContainer.QuestionList;

        var listSize = questionList.Count;

        var iterations = questionsAmount <= listSize ? questionsAmount : listSize;

        if (!scientificallyReferenced.HasValue &&
            !category.HasValue &&
            !difficulty.HasValue)
        {
            return UnspecifiedQuiz(iterations, questionList);
        }

        return SpecifiedQuiz(iterations, questionList, scientificallyReferenced, category, difficulty);
    }

    private Queue<Question> UnspecifiedQuiz(int iterations, List<Question> questionList)
    {
        for (int i = 0; i < iterations; i++)
        {
            var question = questionList[i];
            _selectedQuestions.Add(question);
        }

        return RandomizeQueue();
    }

    private Queue<Question> SpecifiedQuiz(int iterations, List<Question> questionList, bool? scientificallyReferenced, QuestionCategory? category, QuestionDifficulty? difficulty)
    {
        for (int i = 0; i < iterations; i++)
        {
            var question = questionList[i];

            if ((!scientificallyReferenced.HasValue || question.IsReferenced == scientificallyReferenced.Value) &&
                (!category.HasValue || question.Category == category.Value) &&
                (!difficulty.HasValue || question.Difficulty == difficulty.Value))
            {
                _selectedQuestions.Add(question);
            }
        }

        return RandomizeQueue();
    }

    private Queue<Question> RandomizeQueue()
    {
        _tempList = Utilities.RandomizeList(_selectedQuestions);

        foreach (var question in _tempList)
        {
            _tempQueue.Enqueue(question);
        }

        return _tempQueue;
    }
}