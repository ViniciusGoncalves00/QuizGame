using UIInterfaces;

public class CreateQuestionMenu : IReturnable, IHelpful
{
    private readonly CommonUI _commonUI = CommonUI.GetInstance();
    
    public void BackScene()
    {
        _commonUI.SwitchScene(_commonUI.MainMenuScene);
    }
    public void Help()
    {
        throw new System.NotImplementedException();
    }
}
