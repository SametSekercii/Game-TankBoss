using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    
    
    public void SceneLoader(int indexOfScene)
    {
        SceneManager.LoadScene(indexOfScene);

    }
    public void GameExit()
    {

        Application.Quit();
    }
}
