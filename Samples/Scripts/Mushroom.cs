using System;
using UnityEngine;

namespace FGT.Prototypes.HealthSystem.Demo
{
    public class Mushroom : MonoBehaviour
    {
        [SerializeField] HealthSystem _health;
        [SerializeField] Animator _animator;

        public Action<float> OnHealthChanged;
        public Action OnRevive;

        public void OnStart()
        {
            _health = new HealthSystem(100);
            _health.OnHealthChanged += HealthSystem_OnHealthChanged;
            _health.OnDie += OnDie;
            _health.OnRevive += HealthSystem_OnRevive;
        }

        public float GetCurrentHealth()
        {
            return _health.GetCurrent();
        }

        public float GetMaxHealth()
        {
            return _health.GetMax();
        }

        public void ChangeMaxHealth(float newMax)
        {
            _health.SetMax(newMax);
        }

        public void Hit(float damage)
        {
            _health.ReceiveDamage(damage);
        }

        public void Heal(float amount)
        {
            _health.Heal(amount);
        }

        public void Revive(float lifePercentage = 1f)
        {
            _health.Revive(lifePercentage);
        }

        private void HealthSystem_OnHealthChanged(float amount)
        {
            // Hit
            if (amount < 0)
                _animator.SetTrigger("Hit");

            OnHealthChanged?.Invoke(amount);
        }

        private void OnDie()
        {
            _animator.SetTrigger("Die");
        }

        private void HealthSystem_OnRevive()
        {
            _animator.SetTrigger("Revive");

            OnRevive?.Invoke();
        }

        void OnDestroy()
        {
            _health.OnHealthChanged -= HealthSystem_OnHealthChanged;
            _health.OnDie -= OnDie;
            _health.OnRevive -= HealthSystem_OnRevive;
        }
    }
}
