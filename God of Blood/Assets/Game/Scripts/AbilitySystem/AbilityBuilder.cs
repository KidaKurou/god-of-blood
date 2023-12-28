using UnityEngine;

namespace Assets.Scripts.AbilitySystem
{
    public class AbilityBuilder 
    {
        private AbilityConfig _config;
        protected Ability _ability;

        public AbilityBuilder(AbilityConfig config)
        {
            _config = config;
        }

        public virtual void MakeAbility()
        {
            if (_ability != null)
            {
                _ability.SetDescription(_config.Title, _config.Description, _config.DisplayImage);
                _ability.SetCooldownTime(_config.CooldownTime);
                _ability.SetManaCost(_config.ManaCost);
                _ability.SetKey(_config.Hotkey);
                _ability.SetAreaRadius(_config.AreaRadius);
                //_ability.SetAreaParticle(_config.AreaParticle);
                _ability.SetStatus(EAbilityStatus.Ready);
            }
        }

        public virtual Ability GetAbility() => _ability;
    }
}