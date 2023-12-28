using GodofBlood.Units.WarUnits.WarUnitConfig;
using UnityEngine;

public class Paladin : AbstractUnit
{
    [SerializeField] private ParticleSystem _healthParticle;
    [SerializeField] UnitsSO testUnitConfig;
    protected override void Awake()
    {
        _damage = testUnitConfig.Damage;
        _maxHealth = testUnitConfig.Health;
        _attackRate = testUnitConfig.AttackRate;
        _bloodDrop = testUnitConfig.BloodDrop;

        base.Awake();
    }


    public override void AddHealth(float amount)
    {
        if (_currentHealth + amount <= _maxHealth)
        {
            PlayParticle();
            _currentHealth += amount;
        }
        else
        {
            PlayParticle();
            _currentHealth += _maxHealth - _currentHealth;

        }

        healthBar.UpdateHealthBar(_currentHealth, _maxHealth);

        Debug.Log($"health {gameObject.name}");
    }

    private void PlayParticle()
    {
        ParticleSystem go = Instantiate(_healthParticle, transform.position, new Quaternion(_healthParticle.transform.rotation.x, 0, 0, transform.rotation.w), gameObject.transform);
        go.Play();
        Destroy(go, go.main.duration);
    }
}
