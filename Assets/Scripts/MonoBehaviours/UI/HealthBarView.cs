using Entities.Neutral;
using UnityEngine;
using UnityEngine.UI;

namespace MonoBehaviours.UI
{
    [RequireComponent(typeof(Image))]
    public class HealthBarView : MonoBehaviour
    {
        [SerializeField] private Image _healthBar;
        [SerializeField] private EntityComponents entityComponents;

        private void UpdateHealthBarView(float currentHealth, float maxHealth)
        {
            _healthBar.fillAmount = Mathf.Clamp(currentHealth / maxHealth, 0, maxHealth);
        }
        
        private void OnEnable()
        {
            entityComponents.Health.OnValueChanged += UpdateHealthBarView;
        }

        private void OnDisable()
        {
            entityComponents.Health.OnValueChanged -= UpdateHealthBarView;
        }
    }
}