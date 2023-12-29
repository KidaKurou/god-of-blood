using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.AbilitySystem
{
    public class AbilityStorage : MonoBehaviour
    {
        [SerializeField] private AbilityConfig[] _abilityConfigs;

        private List<Ability> _abilities = new();
        
        public void Init()
        {
            for(int i = 0; i < _abilityConfigs.Length; i++)
            {
                var builder = _abilityConfigs[i].GetBuilder();

                builder.MakeAbility();
                _abilities.Add(builder.GetAbility());
            }
        }

        public Ability[] GetAbilities() => _abilities.ToArray();
    }
}