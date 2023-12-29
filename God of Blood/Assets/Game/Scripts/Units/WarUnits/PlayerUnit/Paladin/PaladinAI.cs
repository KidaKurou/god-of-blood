using GodofBlood.Units.WarUnits.WarUnitConfig;
using UnityEngine;

public class PaladinAI : AbstractUnitsAI
{
    private const string WALKCOUNT = "walkCount";
    private const string RUNCOUNT = "runCount";
    private const string PUNCHCOUNT = "punchCount";
    private const string PUNCHVERSCOUNT = "punchVersCount";

    [SerializeField] private UnitsSO testUnitConfig;

    protected override void Awake()
    {
        _idleMoveSpeed = testUnitConfig.IdleMoveSpeed;
        _viewingMoveSpeed = testUnitConfig.ViewingMoveSpeed;
        _attackMoveSpeed = testUnitConfig.AttackMoveSpeed;

        _distanceToTarget = testUnitConfig.DistanceToTarget;
        _distanceToBattle = testUnitConfig.DistanceToBattle;

        _viewingRadius = testUnitConfig.ViewingRadius;
        _attackingRadius = testUnitConfig.AttackingRadius;

        _pointRadius = testUnitConfig.PointRadius;


        base.Awake();
    }
    public override void AttackAnimStart()
    {
        _animator.SetInteger(PUNCHCOUNT, 1);
        AttackVersAnim();
    }

    private void AttackVersAnim()
    {
        _animator.SetInteger(PUNCHVERSCOUNT, Random.Range(0, 2));
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
