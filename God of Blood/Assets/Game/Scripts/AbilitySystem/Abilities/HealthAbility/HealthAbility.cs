using UnityEngine;
using System.Collections.Generic;

namespace GodofBlood.AbilitySystem.Abilities
{
	public class HealthAbility : Ability
	{
		public float HealthCount { get; private set; }

		private List<AbstractUnit> _targets = new List<AbstractUnit>();

		public HealthAbility(float healthCount)
		{
			HealthCount = healthCount;
		}

		public override bool CheckCondition(AbstractUnit owner, List<AbstractUnit> target)
		{
			if (owner == null || target == null)
			{
				return false;
			}

			for (int i = 0; i < target.Count; i++)
			{
                if (target[i].gameObject.tag == "PlayersUnit")
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
						_targets[i].GetComponent<AbstractUnit>().AddHealth(HealthCount);
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