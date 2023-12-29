using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeManager : MonoBehaviour
{
    
    public void ChangeToMainMenu()
    {
        Debug.Log("Time - " + Time.timeScale);
        Time.timeScale = 1f;
        SceneManager.LoadScene(3);
        //GameEventManager.InitServices(3);
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
