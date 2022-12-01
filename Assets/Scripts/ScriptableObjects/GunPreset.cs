using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(menuName = "Weapon Preset/Gun", fileName = "Gun name")]
    public class GunPreset : WeaponPreset
    {
        [SerializeField] private float _reloadTime;
        [SerializeField] private int _ammo;

        public float ReloadTime => _reloadTime;
        public int Ammo => _ammo;
    }
}
