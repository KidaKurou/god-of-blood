using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelSelection : MonoBehaviour
{
    [SerializeField] private bool unlocked;
    public Image unlockImage;
    public GameObject[] stars;

    private void Start()
    {
        //PlayerPrefs.DeleteAll();
    }

    private void Update()
    {
        UpdateLevelImage();
        UpdateLevelStatus();
    }

    private void UpdateLevelStatus()
    {
        int previousLevel = int.Parse(gameObject.name) - 1;
        if (PlayerPrefs.GetInt("Lvl" + previousLevel) > 0)
        {
            unlocked = true;
        }
    }

    private void UpdateLevelImage()
    {
        if (!unlocked) // if unlock is false means This level is clocked
        {
            unlockImage.gameObject.SetActive(true);
            for (int i = 0; i < stars.Length; i++)
            {
                stars[i].gameObject.SetActive(false);
            }
        }
        else // if unlock is true means This level can play
        {
            unlockImage.gameObject.SetActive(false);
            for (int i = 0; i < stars.Length; i++)
            {
                stars[i].gameObject.SetActive(true);
            }
        }
    }

    public void PressSelection(int level)
    {
        if (unlocked)
        {
            //SceneManager.LoadScene(_LevelName);
            GameEventManager.InitServices(level);
        }
    }
}
