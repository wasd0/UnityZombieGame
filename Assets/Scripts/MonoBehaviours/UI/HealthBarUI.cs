using Entities;
using Entities.Neutral;
using UnityEngine;
using UnityEngine.UI;

namespace MonoBehaviours.UI
{
    [RequireComponent(typeof(Image), typeof(IDamageable))]
    public class HealthBarUI : MonoBehaviour
    {
        [SerializeField] private Image _healthBar;
        [SerializeField] private Entity _entity;

        private void UpdateHealthOnBar()
        {
            float max = _entity.MaxHealth;
            float current = _entity.Health;
            _healthBar.fillAmount = Mathf.Clamp(current / max, 0, max);
        }

        private void OnEnable()
        {
            _entity.OnHealthChanged += UpdateHealthOnBar;
        }

        private void OnDisable()
        {
            _entity.OnHealthChanged -= UpdateHealthOnBar;
        }

        private void OnDestroy()
        {
            _entity.OnHealthChanged -= UpdateHealthOnBar;
        }
    }
}