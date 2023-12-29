using UnityEngine;

[CreateAssetMenu(menuName = "configs/UnitSO", fileName = "UnitSO")]
public class UnitsSO : ScriptableObject
{
    [Header("Unit Info")]
    public int Level;

    public string Title;

    public string Description;

    public int Purchase;

    public int Upgrade;

    [Header("testUnit")]
    public float Damage;
    public float Health;
    public float AttackRate;

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

    [Header("RangedUnitBullet")]
    [SerializeField] private float _bulletSpeed;
    public float BulletSpeed => _bulletSpeed;
    [SerializeField] private float _bulletTimeToDestroy;
    public float BulletTimeToDestroy => _bulletTimeToDestroy;

    [SerializeField] private float _bulletJumpPower;
    public float BulletJumpPower => _bulletJumpPower;

    [SerializeField] private float _bulletJumpDuration;
    public float BulletJumpDuration => _bulletJumpDuration;
}
