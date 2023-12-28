using GodofBlood.Units;
using UnityEngine;

public abstract class AbstractUnit : MonoBehaviour, IDie, ITakeDamage, IAttack
{
    [SerializeField] protected Animator _animator;
    [SerializeField] protected FloatingHealthBar healthBar;
    [SerializeField] protected float _currentHealth;

    protected float _damage;
    protected float _maxHealth;
    protected int _bloodDrop;

    protected float _attackRate;

    private float _nextAttackTime;

    protected virtual void Awake()
    {
        healthBar = GetComponentInChildren<FloatingHealthBar>();
        healthBar.gameObject.SetActive(false);
    }
    private void Start()
    {
        _currentHealth = _maxHealth;
        healthBar.UpdateHealthBar(_currentHealth, _maxHealth);
    }
    
    public virtual void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        healthBar.gameObject.SetActive(true);
        healthBar.UpdateHealthBar(_currentHealth, _maxHealth);

        if (_currentHealth <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        Destroy(gameObject);
    }

    public virtual void Attack(ITakeDamage damageable)
    {
        if (Time.time >= _nextAttackTime)
        {
            damageable.TakeDamage(_damage);
            _nextAttackTime = Time.time + 1f / _attackRate;
        }
        else return;
    }

    public virtual void AddHealth(float amount)
    {
        if (_currentHealth + amount <= _maxHealth)
        {
            _currentHealth += amount;
        }
        else
        {
            _currentHealth += _maxHealth - _currentHealth;
        }

        healthBar.UpdateHealthBar(_currentHealth, _maxHealth);

    }
    public virtual void AbilityTakeDamage(float damage)
    {
        TakeDamage(damage);
    }
}
