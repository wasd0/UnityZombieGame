using UnityEngine;

namespace ScriptableObjects.Presets
{
    [CreateAssetMenu(menuName = "Weapon Preset/Weapon", fileName = "Weapon")]
    public class WeaponPreset : ScriptableObject
    {
        [SerializeField] private float _damage;
        [SerializeField] private float _range;
        [SerializeField] private float _attackRate;

        public float Damage => _damage;
        public float Range => _range;
        public float AttackRate => _attackRate;
    }
}