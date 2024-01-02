using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CreateQuestionMenuUI : MonoBehaviour
{
    private readonly DataHandler _dataHandler = DataHandler.GetInstance();
    private readonly CreateQuestionMenu _createQuestionMenu = new CreateQuestionMenu();

    [Header("Buttons")]
    [SerializeField] private Button SubmitQuestionButton;
    [SerializeField] private Button HelpButton;
    [SerializeField] private Button ReferenceButton;
    [SerializeField] private Button BackButton;

    [Header("TMP InputField")]
    [SerializeField] private TMP_InputField Statement;
    [SerializeField] private TMP_InputField CorrectAnswer;
    [SerializeField] private TMP_InputField[] WrongAnswers;
    [SerializeField] private TMP_InputField Explanation;

    [Header("TMP Dropdown")]
    [SerializeField] private TMP_Dropdown Difficulty;
    [SerializeField] private TMP_Dropdown Categories;

    [Header("TMP Texts")]
    [SerializeField] private TMP_Text StatementTitle;
    [SerializeField] private TMP_Text CorrectAnswerTitle;
    [SerializeField] private TMP_Text[] WrongAnswersTitle;
    [SerializeField] private TMP_Text ExplanationTitle;
    [SerializeField] private TMP_Text DifficultyTitle;
    [SerializeField] private TMP_Text CategoriesTitle;

    [SerializeField] private TMP_Text BackTMPText;

    [Header("Texts")]
    [SerializeField] private string BackText;

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
        BackButton.onClick.AddListener(_createQuestionMenu.BackScene);
        // HelpButton.onClick.AddListener(_commonUI.ShowHelpMessage());
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
}