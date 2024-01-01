using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    private readonly DataHandler _dataHandler = DataHandler.GetInstance();
    
    public Button NewGameButton;

    void Start()
    {
        NewGameButton.onClick.AddListener(NewGame);
        
        if (_dataHandler.AllValidQuestions.QuestionList.Count < 1)
        {
            _dataHandler.QuestionCreator.CreateNewQuestion("What year was this game released?", "2024", new[]
            {
                "2021",
                "2022",
                "2023",
            }, "This game began development in 2023 and was released in 2024.", false, QuestionCategory.General, QuestionDifficulty.Easy);
        }
    }

    private void NewGame()
    {
        SceneManager.LoadScene(1);
    }
}