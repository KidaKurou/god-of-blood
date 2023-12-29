using GodofBlood.Units;
using GodofBlood.Units.WarUnits.RangedEnemy;
using UnityEngine;


public class RangedUnitsAI : AbstractUnitsAI
{
    private const string WALKCOUNT = "walkCount";
    private const string RUNCOUNT = "runCount";
    private const string PUNCHCOUNT = "punchCount";

    [SerializeField] private RangedUnit rangedUnit;

    [SerializeField] private UnitsSO rangedUnitsConfig;

    protected override void Awake()
    {
        _idleMoveSpeed = rangedUnitsConfig.IdleMoveSpeed;
        _viewingMoveSpeed = rangedUnitsConfig.ViewingMoveSpeed;
        _attackMoveSpeed = rangedUnitsConfig.AttackMoveSpeed;

        _distanceToTarget = rangedUnitsConfig.DistanceToTarget;
        _distanceToBattle = rangedUnitsConfig.DistanceToBattle;

        _viewingRadius = rangedUnitsConfig.ViewingRadius;
        _attackingRadius = rangedUnitsConfig.AttackingRadius;

        _pointRadius = rangedUnitsConfig.PointRadius;

        base.Awake();
    }

    public override void AttackEnemy()
    {
        transform.LookAt(_target);
        Shoot(_target);
    }

    public override void Attack(ITakeDamage damageable)
    {
        
    }

    private void Shoot(Transform target)
    {
        AttackAnimStart();
        rangedUnit.Shoot(target);
    }
    public override void AttackAnimStart()
    {
        _animator.SetInteger(PUNCHCOUNT, 1);
    }
    public override void AttackAnimEnd()
    {
        _animator.SetInteger(PUNCHCOUNT, 0);
    }
    public override void MoveAnimationStateChanger()
    {
        if (_moveSpeed == _idleMoveSpeed)
        {
            _animator.SetInteger(WALKCOUNT, 1);
        }
        if (_moveSpeed == _viewingMoveSpeed)
        {
            _animator.SetInteger(RUNCOUNT, 1);
        }
        if (_moveSpeed == _attackMoveSpeed)
        {
            _animator.SetInteger(RUNCOUNT, 0);
        }
    }
}
