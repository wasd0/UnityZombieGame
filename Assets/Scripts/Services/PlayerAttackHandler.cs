using System.Collections;
using Entities.Enemy;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Services
{
    [RequireComponent(typeof(Player))]
    public class PlayerAttackHandler : MonoBehaviour
    {
        private Player _player;
        private bool _weaponOnReaload;

        private void Awake()
        {
            _player = GetComponent<Player>();
        }

        private void Update()
        {
            RaycastHit ray;
            Transform playerTransform = _player.transform;
            //TODO: Change shooting system and logic
            bool isHit = Physics.Raycast(playerTransform.position, playerTransform.forward, out ray,
                _player.Weapon.Range);
            if (MouseIsPressed() && !_weaponOnReaload && isHit)
            {
                HandleHitToEnemy(ray);
                _weaponOnReaload = true;
                StartCoroutine(ReloadWeapon());
            }
        }

        private void HandleHitToEnemy(RaycastHit hit)
        {
            GameObject hited = hit.collider.gameObject; 
            if (hited.CompareTag("Enemy"))
            {
                hited.GetComponent<Zombie>().GetDamage(_player);
            }
        }

        private bool MouseIsPressed()
        {
            return Mouse.current.press.ReadValue() > 0;
        }

        private IEnumerator ReloadWeapon()
        {
            yield return new WaitForSeconds(_player.Weapon.DelayInSeconds);
            _weaponOnReaload = false;
        }
    }
}