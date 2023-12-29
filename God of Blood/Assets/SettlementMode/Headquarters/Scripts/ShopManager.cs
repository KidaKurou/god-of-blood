using Assets.Scripts.AbilitySystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    private int currentCoins;
    public Text coinsIU;
    public ShopItemSO[] shopItemsSO;
    public ShopTemplate[] shopPanels;
    public GameObject[] shopPanelsGO;
    public Button[] myPurchaseBtns;

    [Header("Battle")]
    public AbilityConfig[] abilityConfigs;

    private void Start()
    {
        if (PlayerPrefs.HasKey("Blood"))
        {
            currentCoins = PlayerPrefs.GetInt("Blood");
            coinsIU.text = currentCoins.ToString();
        }

        for (int i = 0; i < shopItemsSO.Length; i++)
        {
            shopPanelsGO[i].SetActive(true);
        }
        coinsIU.text = currentCoins.ToString();
        
        //LoadPanels1();
        //CheckPurchaseable1();

        LoadPanels();
        CheckPurchaseable();
    }

    public void CheckPurchaseable()
    {
        currentCoins = PlayerPrefs.GetInt("Blood");
        for (int i = 0; i < shopItemsSO.Length; i++)
        {
            if (currentCoins >= shopItemsSO[i].baseCost)
                myPurchaseBtns[i].interactable = true;
            else
                myPurchaseBtns[i].interactable = false;
        }
    }

    public void PurchaseItem(int btnNo)
    {
        CheckPurchaseable();
        if (currentCoins >= shopItemsSO[btnNo].baseCost)
        {
            currentCoins -= shopItemsSO[btnNo].baseCost;
            coinsIU.text = currentCoins.ToString();
            CheckPurchaseable();
            PlayerPrefs.SetInt("Blood", currentCoins);
            myPurchaseBtns[btnNo].gameObject.SetActive(false);
        }
    }

    public void LoadPanels()
    {
        for (int i = 0; i < shopItemsSO.Length; i++)
        {
            shopPanels[i].titleTxt.text = shopItemsSO[i].title;
            shopPanels[i].costTxt.text = shopItemsSO[i].baseCost.ToString();
        }
    }

    //public void CheckPurchaseable1()
    //{
    //    currentCoins = PlayerPrefs.GetInt("Blood");
    //    for (int i = 0; i < abilityConfigs.Length; i++)
    //    {
    //        if (currentCoins >= abilityConfigs[i].Cost)
    //            myPurchaseBtns[i].interactable = true;
    //        else
    //            myPurchaseBtns[i].interactable = false;
    //    }
    //}

    //public void PurchaseItem1(int btnNo)
    //{
    //    CheckPurchaseable1();
    //    if (currentCoins >= abilityConfigs[btnNo].Cost)
    //    {
    //        currentCoins -= abilityConfigs[btnNo].Cost;
    //        coinsIU.text = currentCoins.ToString();
    //        CheckPurchaseable1();
    //        PlayerPrefs.SetInt("Blood", currentCoins);
    //        myPurchaseBtns[btnNo].gameObject.SetActive(false);
    //    }
    //}

    //public void LoadPanels1()
    //{
    //    for (int i = 0; i < abilityConfigs.Length; i++)
    //    {
    //        shopPanels[i].titleTxt.text = abilityConfigs[i].Title;
    //        shopPanels[i].costTxt.text = abilityConfigs[i].Cost.ToString();
    //    }
    //}
}
