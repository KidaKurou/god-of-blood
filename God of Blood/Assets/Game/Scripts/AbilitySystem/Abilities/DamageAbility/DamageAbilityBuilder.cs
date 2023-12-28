using Assets.Scripts.AbilitySystem;

namespace Assets.Game.Scripts.AbilitySystem.Abilities.DamageAbility
{
    public class DamageAbilityBuilder : AbilityBuilder
    {
        private readonly DamageAbilityConfig _config;
        public DamageAbilityBuilder(DamageAbilityConfig config) : base(config)
        {
            _config = config;
        }

        public override void MakeAbility()
        {
            _ability = new DamageAbility(_config.DamageCount);

            base.MakeAbility();
        }
    }
}
