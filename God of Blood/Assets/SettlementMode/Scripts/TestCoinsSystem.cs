using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TestCoinsSystem : MonoBehaviour
{
    public Text coinsTxt;
    public Text coinsTxt2;
    public Text bloodTxt;
    public int currentCoins = 0;
    public int currentBlood = 0;
    public int getCoins = 10;
    public int getBlood = 10;

    private void Start()
    {
        if (PlayerPrefs.HasKey("Coins"))
        {
            currentCoins = PlayerPrefs.GetInt("Coins");
            UpdateCoins();
        }
        if (PlayerPrefs.HasKey("Blood"))
        {
            currentBlood = PlayerPrefs.GetInt("Blood");
            bloodTxt.text = currentBlood.ToString();
        }

        UpdateCoins();
        bloodTxt.text = currentBlood.ToString();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            GetSomeCoins(getCoins);
            GetSomeBlood(getBlood);
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            DeleteCoins();
            DeleteBlood();
        }
        if (Input.GetKeyDown(KeyCode.Tab)) //QUIT FROM THE GAME
        {
            SceneManager.LoadScene("MainMenu");
        }
    }

    private void GetSomeCoins(int coins)
    {
        currentCoins += coins;
        UpdateCoins();
        PlayerPrefs.SetInt("Coins", currentCoins);
    }

    private void DeleteCoins()
    {
        currentCoins = 0;
        UpdateCoins();
        PlayerPrefs.SetInt("Coins", currentCoins);
    }

    private void GetSomeBlood(int blood)
    {
        currentBlood += blood;
        bloodTxt.text = currentBlood.ToString();
        PlayerPrefs.SetInt("Blood", currentBlood);
    }

    private void DeleteBlood()
    {
        currentBlood = 0;
        bloodTxt.text = currentBlood.ToString();
        PlayerPrefs.SetInt("Blood", currentBlood);
    }

    private void UpdateCoins()
    {
        coinsTxt.text = currentCoins.ToString();
        coinsTxt2.text = currentCoins.ToString();
    }
}
