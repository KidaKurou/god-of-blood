using GodofBlood.Units;
using GodofBlood.Units.WarUnits.RangedEnemy;
using System.Collections;
using UnityEngine;

public class RangedUnitsBullet : MonoBehaviour, IAttack
{
    [SerializeField] private RangedUnit rangedUnit;
    [SerializeField] private UnitsSO rangedUnitsConfig;

    private float _timeToDestroy;
    private float _bulletDamage;

    private WaitForSeconds _timer;

    private void Awake()
    {
        _timeToDestroy = rangedUnitsConfig.BulletTimeToDestroy;
        _bulletDamage = rangedUnitsConfig.Damage;

        _timer = new WaitForSeconds(_timeToDestroy);
    }

    public void Start()
    {
        StartCoroutine(DestructionTimer());
    }

    public void Attack(ITakeDamage damageable)
    {
        damageable.TakeDamage(_bulletDamage);
        Debug.Log($"{gameObject.name} нанес удар -{_bulletDamage}");
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out ITakeDamage damageable) && other.gameObject.tag == "EnemyUnit")
        {
            Debug.Log("ranged attack");
            Attack(damageable);
        }

        DestroyBullet();
    }

    private IEnumerator DestructionTimer()
    {
        yield return _timer;

        DestroyBullet();
    }

    private void DestroyBullet()
    {
        Destroy(gameObject);
    }

}
