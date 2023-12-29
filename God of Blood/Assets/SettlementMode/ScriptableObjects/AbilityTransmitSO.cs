using Assets.Scripts.AbilitySystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Config List", menuName = "Configs/Ability Transmit Config")]
public class AbilityTransmitSO : ScriptableObject
{
    public List<AbilityConfig> Configs = new List<AbilityConfig>();
}
