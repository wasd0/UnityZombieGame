using System;
using System.Collections;
using ScriptableObjects;
using UnityEngine;

namespace Items.Weapon
{
    public abstract class Gun : MonoBehaviour, IWeapon
    {
        [SerializeField] private GunPreset _preset;
        
        private bool _canShoot = true;
        private float _currentAmmo;

        public WeaponPreset Preset => _preset;
        public event Action OnAttack;

        public void Attack()
        {
            if (_currentAmmo > 0)
            {
                _currentAmmo--;
            }
            OnAttack?.Invoke();
        }

        private void OnEnable()
        {
            OnAttack += CheckAmmo;
        }

        private void OnDestroy()
        {
            OnAttack -= CheckAmmo;
        }

        private void CheckAmmo()
        {
            if (_currentAmmo <= 0)
            {
                _currentAmmo = 0;
                StartCoroutine(Reload());
            }
        }

        private IEnumerator Reload()
        {
            if (_canShoot)
            {
                yield break;
            }
            yield return new WaitForSeconds(_preset.ReloadTime);
            _currentAmmo = _preset.Ammo;
            _canShoot = true;
        }
    }
}