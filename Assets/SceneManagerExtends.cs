using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerExtends : SceneManager
{
    private static int _previousScene;
    
    public static void LoadNextScene(int index)
    {
        LoadScene(index);
        _previousScene = index;
    }
    
    public static void BackScene()
    {
        LoadScene(_previousScene);
    }
}
