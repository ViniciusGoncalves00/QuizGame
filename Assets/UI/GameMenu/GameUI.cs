using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField] private QuizManager quizManager;
    
    [Header("Buttons")]
    public Button[] AnswerOptionsDisplay = new Button[4];
    public Button NextQuestionButton;
    
    [Header("TMP Texts")]
    public TMP_Text StatementDisplay;

    private const int OptionsAmount = 4;

    public void SetListeners()
    {
        for (int i = 0; i < AnswerOptionsDisplay.Length; i++)
        {
            var index = i;
            AnswerOptionsDisplay[i].onClick.RemoveAllListeners();
            AnswerOptionsDisplay[i].onClick.AddListener(() => quizManager.CheckAnswer(quizManager.GetAnswersOptions()[index]));
        }

        NextQuestionButton.onClick.RemoveAllListeners();
        NextQuestionButton.onClick.AddListener(quizManager.NextQuestion);
    }

    public void UpdateInterface(Question currentQuestion, List<string> answers)
    {
        StatementDisplay.text = currentQuestion.Statement;

        for (int i = 0; i < OptionsAmount; i++)
        {
            var answerOptionDisplay = AnswerOptionsDisplay[i].GetComponentInChildren<TMP_Text>();
            answerOptionDisplay.text = answers[i];
        }
    }
}