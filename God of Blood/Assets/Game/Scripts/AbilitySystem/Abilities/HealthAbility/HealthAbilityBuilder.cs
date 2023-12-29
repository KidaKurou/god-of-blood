using AbilitySystem.Abilities;
using Assets.Scripts.AbilitySystem;
using UnityEngine;

namespace GodofBlood.AbilitySystem.Abilities
{
    public class HealthAbilityBuilder : AbilityBuilder
    {
        private readonly HealthAbilityConfig _config;
        public HealthAbilityBuilder(HealthAbilityConfig config) : base(config)
        {
            _config = config;
        }

        public override void MakeAbility()
        {
            _ability = new HealthAbility(_config.HealthCount);
            
            base.MakeAbility();
        }
    }
}