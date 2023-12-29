using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartNewGame : MonoBehaviour
{
    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        PlayerPrefs.DeleteAll();
    }
    public void NewGame()
    {
        if (PlayerPrefs.GetInt("Coins") < 1000 || PlayerPrefs.GetInt("Blood") < 1000)
        {
            PlayerPrefs.SetInt("Coins", 1000);
            PlayerPrefs.SetInt("Blood", 100);
        }
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        SceneManager.LoadScene("SettlementMode");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
