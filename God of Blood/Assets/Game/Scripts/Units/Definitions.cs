using UnityEngine;

namespace GodofBlood.Units
{
    public interface IAttack
    {
        public void Attack(ITakeDamage damageable);
    }

    public interface IDie
    {
        public void Die();
    }

    public interface ITakeDamage
    {
        public void TakeDamage(float damage);
    }

    public interface IMoveable
    {
        public void Move();
    }

    public interface IShoot
    {
        public void Shoot(Transform target);
    }
}