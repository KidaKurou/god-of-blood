using Assets.Scripts.AbilitySystem;
using GodofBlood.AbilitySystem.Abilities;
using UnityEngine;

namespace AbilitySystem.Abilities
{
	[CreateAssetMenu(menuName = "Configs/HealthAbilityConfig", fileName = "HealthAbilityConfig")]
	public class HealthAbilityConfig : AbilityConfig
	{
		[field: SerializeField] public float HealthCount { get; private set; }

		public override AbilityBuilder GetBuilder()
		{
			return new HealthAbilityBuilder(this);
		}
	}
}