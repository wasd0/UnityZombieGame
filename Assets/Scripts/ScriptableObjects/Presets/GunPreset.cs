using UnityEngine;

namespace ScriptableObjects.Presets
{
    [CreateAssetMenu(menuName = "Weapon Preset/Gun", fileName = "Gun name")]
    public class GunPreset : WeaponPreset
    {
        [SerializeField] private float _reloadTime;
        [SerializeField] private int _maxAmmo;

        public float ReloadTime => _reloadTime;
        public int MAXAmmo => _maxAmmo;
    }
}
