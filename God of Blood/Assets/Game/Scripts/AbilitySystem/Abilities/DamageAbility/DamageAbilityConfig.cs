using Assets.Scripts.AbilitySystem;
using UnityEngine;

namespace Assets.Game.Scripts.AbilitySystem.Abilities.DamageAbility
{
    [CreateAssetMenu(menuName = "Configs/DamageAbilityConfig", fileName = "DamageAbilityConfig")]
    public class DamageAbilityConfig : AbilityConfig
    {
        [field: SerializeField] public float DamageCount { get; private set; }

        public override AbilityBuilder GetBuilder()
        {
            return new DamageAbilityBuilder(this);
        }
    }
}