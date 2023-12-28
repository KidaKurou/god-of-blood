using UnityEngine;

namespace GodofBlood.Units.WarUnits.RangedEnemy
{
	[CreateAssetMenu(menuName = "Configs/RangedUnitsConfig", fileName = "RangedUnitsConfig")]
	public class RangedUnitsConfig : ScriptableObject
	{
        [Header("RangedUnit")]
        [SerializeField] private float _damage;
        public float Damage => _damage;

        [SerializeField] private float _health;
        public float Health => _health;

        [SerializeField] private float _attackRate;
        public float AttackRate => _attackRate;

        [Header("RangedUnitAI")]
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

        [Header("RangedUnitBullet")]
        [SerializeField] private float _bulletSpeed;
        public float BulletSpeed => _bulletSpeed;
        [SerializeField] private float _bulletTimeToDestroy;
        public float BulletTimeToDestroy => _bulletTimeToDestroy;
        [SerializeField] private float _bulletDamage;
        public float BulletDamage => _bulletDamage;

        [SerializeField] private float _bulletJumpPower;
        public float BulletJumpPower => _bulletJumpPower;

        [SerializeField] private float _bulletJumpDuration;
        public float BulletJumpDuration => _bulletJumpDuration;

    }
}