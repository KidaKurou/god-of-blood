using UnityEngine;

namespace GodofBlood.Units.WarUnits.WarUnitConfig
{
	[CreateAssetMenu(menuName = "Configs/TestUnitConfig", fileName = "TestUnitConfig")]
	public class MeleeUnitConfig : ScriptableObject
	{
        [Header("testUnit")]

        [SerializeField] private float _damage;
        public float Damage => _damage;

        [SerializeField] private float _health;
        public float Health => _health;

        [SerializeField] private float _attackRate;
        public float AttackRate => _attackRate;

        [Header("testUnitAI")]
        [SerializeField] private float _idleMoveSpeed;
        public float IdleMoveSpeed => _idleMoveSpeed;

        [SerializeField] private float _viewingMoveSpeed;
        public float ViewingMoveSpeed => _viewingMoveSpeed;

        [SerializeField] private float _attackMoveSpeed;
        public float AttackMoveSpeed => _attackMoveSpeed;

        [SerializeField] private float _distanceToTarget;
        public float DistanceToTarget => _distanceToTarget;

        [SerializeField] private float _distanceToBattle;
        public float DistanceToBattle => _distanceToBattle;

        [SerializeField] private float _viewingRadius;
        public float ViewingRadius => _viewingRadius;

        [SerializeField] private float _attackingRadius;
        public float AttackingRadius => _attackingRadius;

        [SerializeField] private float _pointRadius;
        public float PointRadius => _pointRadius;

        [SerializeField] private int _bloodDrop;
        public int BloodDrop => _bloodDrop;
    }
}