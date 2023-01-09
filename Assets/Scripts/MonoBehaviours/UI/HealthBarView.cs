using MonoBehaviours.GameObjects.MonoEntity;
using UnityEngine;
using UnityEngine.UI;

namespace MonoBehaviours.UI
{
    [RequireComponent(typeof(Image))]
    public class HealthBarView : MonoBehaviour
    {
        [SerializeField] private Image _healthBar;
        [SerializeField] private DamageableCollidingEntity _damageable;

        private void UpdateHealthBarView(float currentHealth, float maxHealth)
        {
            _healthBar.fillAmount = Mathf.Clamp(currentHealth / maxHealth, 0, maxHealth);
        }
        
        private void OnEnable()
        {
            _damageable.Health.OnValueChanged += UpdateHealthBarView;
        }

        private void OnDisable()
        {
            _damageable.Health.OnValueChanged -= UpdateHealthBarView;
        }
    }
}