using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuizManager : MonoBehaviour
{
    private readonly DataHandler _dataHandler = DataHandler.GetInstance();

    private QuizUI _quizUI;

    private Queue<Question> _questionsQueue = new Queue<Question>();
    private Question _currentQuestion;
    [HideInInspector] public List<string> answersOptions = new List<string>();

    private void Awake()
    {
        _quizUI = FindObjectOfType<QuizUI>();
    }

    private void Start()
    {
        _questionsQueue = _dataHandler.QuizCreator.GenerateQuiz(_dataHandler.AllValidQuestions, 1, false, QuestionCategory.General, QuestionDifficulty.Easy);

        NextQuestion();

        _quizUI.SetListeners();
    }

    public void NextQuestion()
    {
        if (_questionsQueue.Count <= 0)
        {
            FinishGame();
            return;
        }

        _currentQuestion = _questionsQueue.Dequeue();

        answersOptions.Clear();
        answersOptions.AddRange(_currentQuestion.WrongAnswers);
        answersOptions.Add(_currentQuestion.CorrectAnswer);

        answersOptions = Utilities.RandomizeList(answersOptions);

        _quizUI.SetListeners();

        _quizUI.UpdateInterface(_currentQuestion, answersOptions);
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
}