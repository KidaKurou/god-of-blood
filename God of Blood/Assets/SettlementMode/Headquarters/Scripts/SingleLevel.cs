using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SingleLevel : MonoBehaviour
{
    private int currentStars = 0;
    public int levelIndex;

    public void BackButton()
    {
        SceneManager.LoadScene("Headquarters");
    }

    public void PressStarsButton(int _stars)
    {
        currentStars = _stars;
        if (currentStars > PlayerPrefs.GetInt("Lvl" + levelIndex))
        {
            PlayerPrefs.SetInt("Lvl" +  levelIndex, _stars);
        }

        BackButton();
    }
}
