
using System;
using UnityEngine;

namespace FGT.Prototypes.HealthSystem
{
    [Serializable]
    public class HealthSystem
    {
        [SerializeField] float _current;
        [SerializeField] float _max;
        [SerializeField] HealthSystemView _view;

        public Action OnDie;
        public Action<float> OnHealthChanged; //int is the amout changed (negative is damage positive is heal, 0 is max health changed)
        public Action OnRevive;

        public float GetCurrent()
        {
            return _current;
        }

        public float GetMax()
        {
            return _max;
        }

        public HealthSystem(float max, HealthSystemView view = null)
        {
            _max = max;
            _current = max;
            _view = (view != null) ? view : GameObject.FindFirstObjectByType<HealthSystemView>();
            _view.SetPercentage(_current / _max);
        }

        public void ReceiveDamage(float damage)
        {
            if (damage < 0)
                return;

            if (_current == 0)
                return;

            if (damage >= _current)
            {
                _current = 0;
                OnHealthChanged?.Invoke(-damage);
                _view.SetPercentage(_current / _max);
                _view.Hide();
                OnDie?.Invoke();
                return;
            }

            _current -= damage;
            _view.SetPercentage(_current / _max);
            OnHealthChanged?.Invoke(-damage);
        }

        public void Heal(float amount)
        {
            if (amount < 0)
                return;

            if (_current == 0)
                return;

            if (_current + amount > _max)
            {
                _current = _max;
                _view.SetPercentage(_current / _max);
                OnHealthChanged?.Invoke(amount);
                return;
            }

            _current += amount;
            _view.SetPercentage(_current / _max);
            OnHealthChanged?.Invoke(amount);
        }

        public void Revive(float percentageAmount = 1f)
        {
            if (_current > 0)
                return;

            if (percentageAmount < 0f || percentageAmount > 1f)
                return;

            _current = _max * percentageAmount;
            _view.Show();
            _view.SetPercentage(_current / _max);
            OnRevive?.Invoke();
        }

        public void SetMax(float newMax)
        {
            _max = newMax;
            if (_current > _max)
                _current = _max;
            _view.SetPercentage(_current / _max);
            OnHealthChanged?.Invoke(0);
        }
    }
}
