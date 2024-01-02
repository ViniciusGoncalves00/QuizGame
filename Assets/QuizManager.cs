using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    private readonly DataHandler _dataHandler = DataHandler.GetInstance();
    private readonly QuizCreator _quizCreator = new QuizCreator();

    [SerializeField] private GameUI gameUI;

    private Queue<Question> _questionsQueue = new Queue<Question>();
    private Question _currentQuestion;
    private List<string> _answersOptions = new List<string>();

    private void Start()
    {
        _questionsQueue = _quizCreator.GenerateQuiz(_dataHandler.AllValidQuestions, 1, false, QuestionCategory.General, QuestionDifficulty.Easy);

        NextQuestion();

        gameUI.SetListeners();
    }

    public void NextQuestion()
    {
        if (_questionsQueue.Count <= 0)
        {
            FinishGame();
            return;
        }

        _currentQuestion = _questionsQueue.Dequeue();

        _answersOptions.Clear();
        _answersOptions.AddRange(_currentQuestion.WrongAnswers);
        _answersOptions.Add(_currentQuestion.CorrectAnswer);

        _answersOptions = Utilities.RandomizeList(_answersOptions);

        gameUI.SetListeners();

        gameUI.UpdateInterface(_currentQuestion, _answersOptions);
    }

    public void CheckAnswer(string selectedAnswer)
    {
        if (selectedAnswer == _currentQuestion.CorrectAnswer)
        {
            Debug.Log("Correct Answer");
        }
        else
        {
            Debug.Log("Wrong Answer");
        }
    }

    private void FinishGame()
    {
        //TODO something different of this

        BackToMainMenu();
    }

    private void BackToMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public List<string> GetAnswersOptions()
    {
        return _answersOptions;
    }
}