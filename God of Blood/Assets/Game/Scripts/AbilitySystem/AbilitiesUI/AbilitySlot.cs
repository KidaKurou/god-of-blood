using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Game.AbilitySystem.AbilityUI
{
    public class AbilitySlot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        public event Action<int> OnClick;

        [Header("References")]
        [SerializeField] private GameObject _rootObject;
        [SerializeField] private Image _displayImage;
        [SerializeField] private Image _cooldownImage;
        [SerializeField] private Image _borderImage;
        [SerializeField] private TMP_Text _cooldownText;
        [SerializeField] private GameObject _manaPanel;
        [SerializeField] private TMP_Text _manaText;

        private int _abilityIndex;

        public void Show() => _rootObject.SetActive(true);
        public void SetAbility(int index) => _abilityIndex = index;
        public void SetDisplayImage(Sprite displayImage) => _displayImage.sprite = displayImage;
        public void SetCooldownText(float current, float max)
        {
            if (current <= 0.0f)
            {
                _cooldownText.text = string.Empty;
                _cooldownImage.fillAmount = 0.0f;
            }
            else
            {
                _cooldownText.text = Mathf.RoundToInt(current).ToString();
                _cooldownImage.fillAmount = current / max;
            }
        }

        public void SetManaText(float mana)
        {
            if (mana <= 0.0f)
            {
                _manaPanel.SetActive(false);
            }
            else
            {
                _manaPanel.SetActive(true);
                _manaText.text = Mathf.RoundToInt(mana).ToString();
            }
        }

        public void Hide() => _rootObject.SetActive(false);

        public void OnPointerEnter(PointerEventData eventData)
        {
            _borderImage.gameObject.SetActive(true);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            _borderImage.gameObject.SetActive(false);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            OnClick?.Invoke(_abilityIndex);
        }
    }
}