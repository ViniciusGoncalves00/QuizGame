using UIInterfaces;

public class CreateQuizMenu : IReturnable, IHelpful
{
    private readonly CommonUI _commonUI = CommonUI.GetInstance();

    public void BackScene()
    {
        _commonUI.SwitchScene(_commonUI.MainMenuScene);
    }
    
    public void StartGame()
    {
        _commonUI.SwitchScene(_commonUI.GameScene);
    }

    public void Help()
    {
        throw new System.NotImplementedException();
    }
}