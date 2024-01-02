using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    private readonly MainMenu _mainMenu = new MainMenu();
    
    [Header("Buttons")]
    [SerializeField] private Button NewGameButton;
    [SerializeField] private Button CreateQuestionButton;
    [SerializeField] private Button OptionsButton;
    [SerializeField] private Button QuitGameButton;
    
    [Header("TMP Texts")]
    [SerializeField] private TMP_Text NewGameTMPText;
    [SerializeField] private TMP_Text CreateQuestionTMPText;
    [SerializeField] private TMP_Text OptionsTMPText;
    [SerializeField] private TMP_Text QuitGameTMPText;
    
    [Header("Texts")]
    [SerializeField] private string NewGameText;
    [SerializeField] private string CreateQuestionText;
    [SerializeField] private string OptionsText;
    [SerializeField] private string QuitGameText;

    private void Awake()
    {
        NewGameTMPText.text = NewGameText;
        CreateQuestionTMPText.text = CreateQuestionText;
        OptionsTMPText.text = OptionsText;
        QuitGameTMPText.text = QuitGameText;
    }
    void Start()
    {
        NewGameButton.onClick.AddListener(_mainMenu.NewGame);
        CreateQuestionButton.onClick.AddListener(_mainMenu.CreateQuestion);
        OptionsButton.onClick.AddListener(_mainMenu.OptionsMenu);
        QuitGameButton.onClick.AddListener(_mainMenu.QuitGame);
    }
    
#if UNITY_EDITOR
    private void OnValidate()
    {
        NewGameTMPText.text = NewGameText;
        CreateQuestionTMPText.text = CreateQuestionText;
        OptionsTMPText.text = OptionsText;
        QuitGameTMPText.text = QuitGameText;
    }
#endif
}