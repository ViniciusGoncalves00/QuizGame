using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class OptionsUI : MonoBehaviour
{
    private OptionsMenu _optionsMenu;

    [SerializeField] private GameObject ButtonPrefab;
    [SerializeField] private GameObject Background;
    
    [Header("Buttons")]
    [SerializeField] private Button BackButton;
    [SerializeField] private Button DarkModeButton;
    
    [Header("TMP Texts")]
    [SerializeField] private TMP_Text BackTMPText;
    [SerializeField] private TMP_Text DarkModeTMPText;
    
    [Header("Texts")]
    [SerializeField] private string BackText;
    [SerializeField] private string DarkModeText;

    private void Awake()
    {
        _optionsMenu = new OptionsMenu(ButtonPrefab, Background);
        
        BackTMPText.text = BackText;
        DarkModeTMPText.text = DarkModeText;
    }

    void Start()
    {
        BackButton.onClick.AddListener(_optionsMenu.BackScene);
        DarkModeButton.onClick.AddListener(_optionsMenu.DarkMode);
    }

#if UNITY_EDITOR
    private void OnValidate()
    {
        BackTMPText.text = BackText;
        DarkModeTMPText.text = DarkModeText;
    }
#endif
}