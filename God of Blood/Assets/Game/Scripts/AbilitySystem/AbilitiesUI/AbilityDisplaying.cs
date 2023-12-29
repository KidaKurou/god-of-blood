using System;
using System.Collections;
using UnityEngine;

namespace Game.AbilitySystem.AbilityUI
{
    public class AbilityDisplaying : MonoBehaviour
    {
        public event Action<int> OnClickAbility;

        [SerializeField] private RectTransform _widgetContainer;
        [SerializeField] private AbilitySlot _slotWidget;

        public void Init(Ability[] abilities)
        {
            Debug.Log("init");
            for (int i = 0; i < abilities.Length; ++i) 
            {
                AbilitySlot widget = Instantiate(_slotWidget, _widgetContainer);
                
                widget.SetDisplayImage(abilities[i].DisplayImage);
                widget.SetManaText(abilities[i].ManaCost);
                widget.SetAbility(i);
                widget.OnClick += OnClick;

                abilities[i].EventChangeCooldownTimer += widget.SetCooldownText;
            }
        }

        private void OnClick(int index)
        {
            OnClickAbility?.Invoke(index);
        }
    }
}