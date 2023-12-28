using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeManager : MonoBehaviour
{
    
    public void ChangeToMainMenu()
    {
        //SceneManager.LoadScene();
    }

    public void RestartLevel()
    {
        GameEventManager.InitServices(SceneManager.GetActiveScene().buildIndex);
    }

    public void ChangeToNextLevel()
    {
        GameEventManager.InitServices(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
