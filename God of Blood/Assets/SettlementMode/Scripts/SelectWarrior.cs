using GodofBlood.Deployment;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectWarrior : MonoBehaviour
{
    [Header("Select Settings")]
    [SerializeField] private Button previousBtn;
    [SerializeField] private Button nextBtn;
    [SerializeField] private UnitsSO[] unitsSO;
    [SerializeField] private GameObject[] shopItems;

    [Header("Purchase Settings")]
    [SerializeField] private Button purchaseBtn;
    [SerializeField] private Text _totalCost;
    [SerializeField] private Text[] coinsTxt;
    [SerializeField] private Slider _slider;
    [SerializeField] private Text _quantityText;
    [SerializeField] private TroopsGroupConfig[] squadSO;

    [Header("Upgrade Settings")]
    [SerializeField] private Button upgradeBtn;

    private GameObject currentUnit = null;
    private int currentItem;
    private int currentCoins;

    private int _baseCost;
    private int _baseQuanity;

    private void Awake()
    {
        currentCoins = PlayerPrefs.GetInt("Coins");
        currentUnit = transform.GetChild(0).gameObject;
        _baseQuanity = 1;
        SelectItem(0);
        //LoadUnits();
    }

    private void Start()
    {
        _baseCost = unitsSO[0].Purchase;

        _slider.onValueChanged.AddListener((v) =>
        {
            _quantityText.text = "Quantity: " + v.ToString("0");
            _totalCost.text = "Total Cost: " + (_baseCost * v);
            CheckPurchaseable();
        });
    }

    private void SelectItem(int _index)
    {
        previousBtn.interactable = (_index != 0);
        nextBtn.interactable = (_index != transform.childCount - 1);

        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(i == _index);
            transform.GetChild(i).gameObject.GetComponent<Animator>().enabled = (i == _index);
            if (i == _index)
                currentUnit = transform.GetChild(i).gameObject; //???????????
        }

        LoadUnits();
    }

    public void ChangeItem(int _change)
    {
        currentItem += _change;
        SelectItem(currentItem);
    }

    private void LoadUnits()
    {
        foreach (var unitSO in unitsSO)
        {
            if (unitSO.name.Contains(currentUnit.name))
            {
                CheckUpgradable(unitSO);
                shopItems[0].transform.GetChild(1).GetComponent<Text>().text = $"Level: {unitSO.Level}";
                shopItems[0].transform.GetChild(2).GetComponent<Text>().text = $"Title: {unitSO.Title}";
                shopItems[0].transform.GetChild(3).GetComponent<Text>().text = $"Damage: {unitSO.Damage}";
                shopItems[0].transform.GetChild(4).GetComponent<Text>().text = $"Upgrade: {unitSO.Upgrade}";
                shopItems[0].transform.GetChild(5).GetComponent<Text>().text = $"Health: {unitSO.Health}";
                shopItems[0].transform.GetChild(6).GetComponent<Text>().text = $"Total Cost: {unitSO.Purchase}";
                shopItems[0].transform.GetChild(7).GetComponent<Text>().text = $"Attack Rate: {unitSO.AttackRate}";
                shopItems[0].transform.GetChild(8).GetComponent<Text>().text = $"Quantity: {_baseQuanity}"; //QUANTITY

                shopItems[1].transform.GetChild(2).GetComponent<Text>().text = $"{unitSO.Description}";

                _baseCost = unitSO.Purchase;
                return;
            }
        }
    }

    public void PurchaseUnits()
    {
        CheckPurchaseable();
        for (int i = 0; i < unitsSO.Length; i++)
        {
            if (unitsSO[i].name.Contains(currentUnit.name))
            {
                if (currentCoins >= int.Parse(_totalCost.text.Substring(12)))
                {
                    currentCoins -= int.Parse(_totalCost.text.Substring(12));
                    PlayerPrefs.SetInt("Coins", currentCoins);
                    squadSO[i].Quantity += int.Parse(_quantityText.text.Substring(10));
                    UpdateCoins();
                    CheckPurchaseable();
                    CheckUpgradable(unitsSO[i]);
                }
                return;
            }
        }
    }

    private void CheckPurchaseable()
    {
        currentCoins = PlayerPrefs.GetInt("Coins");
        if (currentCoins >= int.Parse(_totalCost.text.Substring(12)))
            purchaseBtn.interactable = true;
        else
            purchaseBtn.interactable = false;
    }

    private void CheckUpgradable(UnitsSO unitsSO)
    {
        currentCoins = PlayerPrefs.GetInt("Coins");
        if (currentCoins >= unitsSO.Upgrade)
            upgradeBtn.interactable = true;
        else
            upgradeBtn.interactable = false;
    }

    private void UpdateCoins()
    {
        foreach (var coin in coinsTxt)
        {
            coin.text = currentCoins.ToString();
        }
    }

    public void UpgradeUnits()
    {
        for (int i = 0; i < unitsSO.Length; i++)
        {
            if (unitsSO[i].name.Contains(currentUnit.name))
            {
                CheckUpgradable(unitsSO[i]);
                if (currentCoins >= unitsSO[i].Upgrade)
                {
                    currentCoins -= unitsSO[i].Upgrade;
                    PlayerPrefs.SetInt("Coins", currentCoins);
                    UpdateCoins();
                    CheckUpgradable(unitsSO[i]);
                    UpgradeUnitsStats(unitsSO[i]);
                    CheckPurchaseable();
                    LoadUnits();
                }
                return;
            }
        }
    }

    private void UpgradeUnitsStats(UnitsSO unitsSO)
    {
        unitsSO.Level += 1;
        unitsSO.Purchase *= 2;
        unitsSO.Upgrade *= 2;
        unitsSO.Damage += 5;
        unitsSO.Health += 10;
        unitsSO.AttackRate += 0.2f;
    }
}
