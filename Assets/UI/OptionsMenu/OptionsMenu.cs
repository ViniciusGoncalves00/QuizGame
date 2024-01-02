using TMPro;
using UIInterfaces;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : IReturnable, IHelpful
{
    private readonly CommonUI _commonUI = CommonUI.GetInstance();

    private readonly GameObject _button;
    private readonly GameObject _background;

    private readonly Color _darkGrey = new Color(0.1f, 0.1f, 0.1f, 1);

    
    public OptionsMenu(GameObject button, GameObject background)
    {
        _button = button;
        _background = background;
    }
    public void BackScene()
    {
        // if (_commonUI.PreviousScene == _commonUI.GameScene)
        // {
        //     _commonUI.SwitchScene(_commonUI.GameScene);
        // }
        // else
        // {
            _commonUI.SwitchScene(_commonUI.MainMenuScene);
        // }
    }

    public void Help()
    {
        throw new System.NotImplementedException();
    }

    public void DarkMode()
    {
        _commonUI.DarkModeActive = !_commonUI.DarkModeActive;

        if (_commonUI.DarkModeActive)
        {
            _button.GetComponent<Image>().color = _darkGrey;
            _button.GetComponentInChildren<TMP_Text>().color = Color.white;
            _background.GetComponent<Image>().color = _darkGrey;
        }
        else
        {
            _button.GetComponent<Image>().color = Color.white;
            _button.GetComponentInChildren<TMP_Text>().color = _darkGrey;
            _background.GetComponent<Image>().color = Color.white;
        }
    }
}