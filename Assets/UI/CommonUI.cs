using UnityEngine;
using UnityEngine.SceneManagement;

public class CommonUI
{
    private static readonly CommonUI Instance = new CommonUI();
    
    public delegate void MethodToConfirm();

    public readonly string MainMenuScene = "MainMenu";
    public readonly string GameScene = "Game";
    public readonly string CreateQuizScene = "CreateQuiz";
    public readonly string CreateQuestionScene = "CreateQuestion";
    public readonly string OptionsScene = "Options";

    public string PreviousScene { get; private set; }
    public string CurrentScene = "MainMenu";
    
    public bool DarkModeActive;

    private CommonUI()
    {
    }

    public static CommonUI GetInstance()
    {
        return Instance;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ConfirmationMessage(string message, MethodToConfirm methodToConfirm)
    {
        OpenWindow(message);
        methodToConfirm?.Invoke();
    }
    
    public void ShowHelpMessage(string message)
    {
        OpenWindow(message);
    }

    public void OpenWindow(string message)
    {
        
    }
    
    public void SwitchScene(string newScene)
    {
        SceneManager.LoadScene(newScene);
        PreviousScene = CurrentScene;
        CurrentScene = newScene;
        SceneManager.UnloadSceneAsync(CurrentScene);
    }
}