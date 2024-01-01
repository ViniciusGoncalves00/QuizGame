using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class CreateQuestionMenuUI : MonoBehaviour
{
    private readonly DataHandler _dataHandler = DataHandler.GetInstance();
    
    public Button SubmitQuestionButton;
    public Button HelpButton;
    public Button ReferenceButton;

    public TMP_Text StatementTitle;
    public TMP_InputField Statement;
    public TMP_Text CorrectAnswerTitle;
    public TMP_InputField CorrectAnswer;
    public TMP_Text[] WrongAnswersTitle;
    public TMP_InputField[] WrongAnswers;
    public TMP_Text ExplanationTitle;
    public TMP_InputField Explanation;
    
    public TMP_Text DifficultyTitle;
    public TMP_Dropdown Difficulty;
    public TMP_Text CategoriesTitle;
    public TMP_Dropdown Categories;
    
    public bool IsReferenced;

    private QuestionCategory _questionCategory;
    private QuestionDifficulty _questionDifficulty;

    private readonly List<TMP_Dropdown.OptionData> _difficultyOptions = new List<TMP_Dropdown.OptionData>();
    private readonly List<TMP_Dropdown.OptionData> _categoryOptions = new List<TMP_Dropdown.OptionData>();

    private QuestionCreator _questionCreator = new QuestionCreator();
    
    void Start()
    {
        StatementTitle.text = "Question Statement";
        CorrectAnswerTitle.text = "Correct Answer";
        for (int i = 0; i < WrongAnswers.Length; i++)
        {
            WrongAnswersTitle[i].text = $"Wrong Answer {i}";
        }
        ExplanationTitle.text = "Explanation";
        
        SubmitQuestionButton.onClick.AddListener(SubmitQuestion);
        HelpButton.onClick.AddListener(ShowHelpMessage);
    }
    
    void Update()
    {
        
    }
    
    private void SubmitQuestion()
    {
        string[] answers = new string[4];

        for (int i = 0; i < WrongAnswers.Length; i++)
        {
            answers[i] = WrongAnswers[i].text;
        }

        _questionCreator.CreateNewQuestion(Statement.text, CorrectAnswer.text, answers, Explanation.text, IsReferenced, _questionCategory, _questionDifficulty);
    }

    private void ShowHelpMessage()
    {
        
    }
}
