using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class CreateQuizUI : MonoBehaviour
{
    private readonly DataHandler _dataHandler = DataHandler.GetInstance();
    private readonly CreateQuizMenu _createQuizMenu = new CreateQuizMenu();
    private readonly QuestionCreator _questionCreator = new QuestionCreator();
    
    [Header("Buttons")]
    [SerializeField] private Button StartGameButton;
    [SerializeField] private Button BackButton;
    
    [Header("TMP Texts")]
    [SerializeField] private TMP_Text StartGameTMPText;
    [SerializeField] private TMP_Text BackTMPText;
    
    [Header("Texts")]
    [SerializeField] private string StartGameText;
    [SerializeField] private string BackText;
    
    private void Awake()
    {
        StartGameTMPText.text = StartGameText;
        BackTMPText.text = BackText;
    }
    
    void Start()
    {
        StartGameButton.onClick.AddListener(_createQuizMenu.StartGame);
        BackButton.onClick.AddListener(_createQuizMenu.BackScene);
        
        if (_dataHandler.AllValidQuestions.QuestionList.Count < 1)
        {
            _questionCreator.CreateNewQuestion("What year was this game released?", "2024", new[]
            {
                "2021",
                "2022",
                "2023",
            }, "This game began development in 2023 and was released in 2024.", false, QuestionCategory.General, QuestionDifficulty.Easy);
        }
    }
    
#if UNITY_EDITOR
    private void OnValidate()
    {
        StartGameTMPText.text = StartGameText;
        BackTMPText.text = BackText;
    }
#endif
}
