using UnityEngine;
using DG.Tweening;

namespace GodofBlood.Units.WarUnits.RangedEnemy
{
	public class RangedUnit : AbstractUnit
	{
        private const int BULLETNUMOFJUMP = 1;

        [SerializeField] private ParticleSystem _healthParticle;

        [SerializeField] private UnitsSO rangedUnitsConfig;

        [SerializeField] private GameObject _bulletPrefab;
        [SerializeField] public Transform _shootPoint;

        private float _bulletJumpPower;
        private float _bulletJumpDuration;
        private float _nextShootTime;

        protected override void Awake()
        {
            _maxHealth = rangedUnitsConfig.Health;
            _attackRate = rangedUnitsConfig.AttackRate;

            _bulletJumpDuration = rangedUnitsConfig.BulletJumpDuration;
            _bulletJumpPower = rangedUnitsConfig.BulletJumpPower;

            base.Awake();
        }


        public override void Attack(ITakeDamage damageable)
        {

        }

        public void Shoot(Transform target)
        {

            if (Time.time >= _nextShootTime)
            {
                var bullet = Instantiate(_bulletPrefab, _shootPoint.position, Quaternion.Euler(0, transform.eulerAngles.y, 0));
                bullet.transform.DOJump(target.position, _bulletJumpPower, BULLETNUMOFJUMP, _bulletJumpDuration).SetEase(Ease.Linear);
                _nextShootTime = Time.time + 1f / _attackRate;
            }

            else
            {
                return;
            }

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
}