using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BloodBank : MonoBehaviour
{
    private int currencyAmount = 0;

    private void Awake()
    {
        GameEventManager.onEnemyDied.AddListener(AddCurrency);
    }

    public void AddCurrency(int amount)
    {
        currencyAmount += amount;
        UpdateCurrencyText();
    }

    public void SpendCurrency(int amount)
    {
        if (currencyAmount >= amount)
        {
            currencyAmount -= amount;
            UpdateCurrencyText();
        }
        else
        {
            Debug.Log("Недостаточно валюты для совершения покупки!");
        }
    }


    void UpdateCurrencyText()
    {
        UIEventManager.BloodBankEvent(currencyAmount);
    }
}
