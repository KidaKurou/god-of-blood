using UnityEngine;
using UnityEngine.UI;

namespace Assets.Game.Scripts.UI
{
    public class UIBloodBank : MonoBehaviour
    {

        [SerializeField] private Text currencyBloodText;

        private void Awake()
        {
            UIEventManager.onBloodBankChanged.AddListener(OutputBloodAmounts);
        }

        private void OutputBloodAmounts(int unit)
        {
            currencyBloodText.text = "Blood: " + unit.ToString();
        }
    }
}