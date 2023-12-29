using GodofBlood.Units;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public abstract class AbstractUnitsAI : MonoBehaviour
{
    private const string IDLECOUNT = "idleCount";

    [SerializeField] protected Animator _animator;

    [SerializeField] protected LayerMask _targetLayerMask;

    [SerializeField] protected Transform _attackPoint;
    protected float _pointRadius;

    protected float _idleMoveSpeed;
    protected float _viewingMoveSpeed;
    protected float _attackMoveSpeed;

    protected float _moveSpeed;
    protected float _distanceToTarget;
    protected float _distanceToBattle;

    protected float _viewingRadius;
    protected float _attackingRadius;

    [SerializeField]protected Transform _target;

    protected AbstractUnit abstractUnitScript;

    private State currentState = State.Idle;

    private enum State
    {
        Idle,
        Searching,
        Moving,
        Attacking
    }

    protected virtual void Awake()
    {
        abstractUnitScript = GetComponent<AbstractUnit>();
    }

    protected virtual private void Start()
    {
        _moveSpeed = _idleMoveSpeed;
        _animator.SetInteger(IDLECOUNT, Random.Range(0, 2));
    }

    protected virtual void Update()
    {
        if (Time.timeScale == 1)
        {
            switch (currentState)
            {
                case State.Idle:
                    UpdateIdleState();
                    break;
                case State.Searching:
                    UpdateSearchState();
                    break;
                case State.Moving:
                    UpdateMoveState();
                    break;
                case State.Attacking:
                    UpdateAttackState();
                    break;
            }
            MoveAnimationStateChanger();
        }
    }

    //private void OnDrawGizmosSelected()
    //{
    //    Gizmos.color = new Color(0.8f, 0.3f, 0.1f, 0.2f);
    //    Gizmos.DrawSphere(_attackPoint.position, _pointRadius);

    //}


    public virtual void UpdateIdleState()
    {
        currentState = State.Searching;
    }

    public virtual void UpdateSearchState()
    {
        Collider[] enemies = Physics.OverlapSphere(transform.position, _viewingRadius, _targetLayerMask);

        if (enemies.Length > 0)
        {
            if (_target == null)
            {
                _target = enemies[0].transform;
                _moveSpeed = _viewingMoveSpeed;
            }
        }
            currentState = State.Moving;
    }

    public virtual void UpdateMoveState()
    {
        transform.LookAt(_target);
        transform.Translate(Vector3.forward * _moveSpeed * Time.deltaTime);

        if (_target != null)
        {
            if (Vector3.Distance(transform.position, _target.transform.position) < _distanceToTarget)
            {
                currentState = State.Attacking;
            }
            if (Vector3.Distance(transform.position, _target.transform.position) < _distanceToBattle)
            {
                _moveSpeed = _attackMoveSpeed;
            }

        }
        else
            currentState = State.Searching;
    }

    public virtual void UpdateAttackState()
    {
        if (_target != null)
        {
            if (Vector3.Distance(transform.position, _target.transform.position) < _distanceToTarget)
            {
                AttackEnemy();
            }
            else
            {
                currentState = State.Moving;
            }
        }
        else
        {
            Collider[] enemies = Physics.OverlapSphere(transform.position, _attackingRadius, _targetLayerMask);

            if (enemies.Length > 0)
            {
                _target = enemies[0].transform;
                transform.LookAt(_target);
            }
            else
            {
                AttackAnimEnd();
                _moveSpeed = _viewingMoveSpeed;
                currentState= State.Searching;
            }
        }
    }

    public virtual void AttackEnemy()
    {
        Collider[] enemiesToDamage = Physics.OverlapSphere(_attackPoint.position, _pointRadius, _targetLayerMask);
        if (enemiesToDamage == null)
        {
            return;
        }
        //else if (enemiesToDamage.Length > 1)
        //{
        //    for (int i = 0; i < enemiesToDamage.Length; i++)
        //    {
        //        enemiesToDamage[i].gameObject.TryGetComponent(out ITakeDamage damageable);
        //        Attack(damageable);

        //    }
        //}
        else if (enemiesToDamage.Length > 0)
        {
            AttackAnimStart();
            enemiesToDamage[Random.Range(0, enemiesToDamage.Length - 1)].gameObject.TryGetComponent(out ITakeDamage damageable);
            Attack(damageable);
        }
    }

    public virtual void Attack(ITakeDamage damageable)
    {
        abstractUnitScript.Attack(damageable);
    }

    public virtual void AttackAnimStart()
    {

    }
    public virtual void AttackAnimEnd()
    {

    }
    public virtual void MoveAnimationStateChanger()
    {

    }
}