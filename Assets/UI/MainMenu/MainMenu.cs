using UIInterfaces;

public class MainMenu : IHelpful, IQuitable
{
    private readonly CommonUI _commonUI = CommonUI.GetInstance();
    
    private const string QuitMessage = "Are you sure you want to quit?";
    
    public void NewGame()
    {
        _commonUI.SwitchScene(_commonUI.CreateQuizScene);
    }
    
    public void CreateQuestion()
    {
        _commonUI.SwitchScene(_commonUI.CreateQuestionScene);
    }

    public void OptionsMenu()
    {
        _commonUI.SwitchScene(_commonUI.OptionsScene);
    }
    
    public void Help()
    {
        throw new System.NotImplementedException();
    }
    public void QuitGame()
    {
        _commonUI.ConfirmationMessage(QuitMessage, _commonUI.QuitGame);
    }
}