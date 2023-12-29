using GodofBlood.Units.WarUnits.WarUnitConfig;
using UnityEngine;

public class Mutant : AbstractUnit
{
    [SerializeField] private ParticleSystem _healthParticle;
    [SerializeField] MeleeUnitSO testUnitConfig;
    protected override void Awake()
    {
        _damage = testUnitConfig.Damage;
        _maxHealth = testUnitConfig.Health;
        _attackRate = testUnitConfig.AttackRate;
        _bloodDrop = testUnitConfig.BloodDrop;

        base.Awake();
    }

    public override void Die()
    {
        GameEventManager.BloodAddedEvent(_bloodDrop);
        base.Die();
    }

    public override void AbilityTakeDamage(float damage)
    {
        PlayParticle();
        base.AbilityTakeDamage(damage);
    }
    private void PlayParticle()
    {
        ParticleSystem go = Instantiate(_healthParticle, transform.position, new Quaternion(_healthParticle.transform.rotation.x, 0, 0, transform.rotation.w), gameObject.transform);
        go.Play();
        Destroy(go, go.main.duration);
    }
}
