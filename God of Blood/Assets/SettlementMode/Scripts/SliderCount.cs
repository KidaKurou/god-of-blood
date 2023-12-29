using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderCount : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Text _sliderText;

    [SerializeField] private Text _totalCost;
    private int _baseCost;
    private void Start()
    {
        _baseCost = int.Parse(_totalCost.text.Substring(12));
        _slider.onValueChanged.AddListener((v) =>
        {
            _sliderText.text = "Quantity: " + v.ToString("0");
            _totalCost.text = "Total Cost: " + (_baseCost * v).ToString();
        });
    }
}
