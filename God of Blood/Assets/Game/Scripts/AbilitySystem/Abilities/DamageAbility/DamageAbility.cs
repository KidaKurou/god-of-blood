using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Game.Scripts.AbilitySystem.Abilities.DamageAbility
{
    public class DamageAbility : Ability
    {
        public float DamageCount { get; private set; }

        private List<AbstractUnit> _targets = new List<AbstractUnit>();

        public DamageAbility(float damageCount)
        {
            DamageCount = damageCount;
        }

        public override bool CheckCondition(AbstractUnit owner, List<AbstractUnit> target)
        {
            if (owner == null || target == null)
            {
                return false;
            }

            for (int i = 0; i < target.Count; i++)
            {
                if (target[i].gameObject.tag == "EnemyUnit")
                {
                    _targets.Add(target[i]);
                    continue;
                }
                continue;
            }


            return true;
        }

        public override void ApplyCast()
        {
            if (_targets != null)
            {
                for (int i = 0; i < _targets.Count; i++)
                {
                    if (_targets[i] != null)
                    {
                        Debug.Log("ApplyCast work");
                        _targets[i].GetComponent<AbstractUnit>().AbilityTakeDamage(DamageCount);
                    }
                }
                _targets.Clear();
                ChangeCooldownTimer(CooldownTime);
                SetStatus(Assets.Scripts.AbilitySystem.EAbilityStatus.Cooldown);
            }
        }

        public override void EventTick(float deltaTick)
        {
            if (Status == Assets.Scripts.AbilitySystem.EAbilityStatus.Cooldown)
            {
                ChangeCooldownTimer(CooldownTimer - deltaTick);

                if (CooldownTimer <= 0.0f)
                {
                    SetStatus(Assets.Scripts.AbilitySystem.EAbilityStatus.Ready);
                }
            }
        }
    }

}
