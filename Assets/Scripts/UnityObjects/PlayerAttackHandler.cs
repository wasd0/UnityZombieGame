using System.Collections;
using Entities;
using Entities.Enemy;
using Services;
using UnityEngine;
using Zenject;

namespace UnityObjects
{
    [RequireComponent(typeof(Player))]
    public class PlayerAttackHandler : MonoBehaviour
    {
        private Player _player;
        private bool _isCooldownActive;
        private MouseService _mouseService;

        [Inject]
        private void Construct(MouseService mouseService)
        {
            _mouseService = mouseService;
        }

        private void Awake()
        {
            _player = GetComponent<Player>();
        }

        private void AttackZombies()
        {
            bool isHit = TryGetHitToObject(out var ray);
            if (!_isCooldownActive && isHit)
            {
                HandleHitToZombie(ray);
                StartCoroutine(WaitForCooldown());
            }
        }

        private bool TryGetHitToObject(out RaycastHit hit)
        {
            Transform playerTransform = _player.transform;
            return Physics.Raycast(playerTransform.position, playerTransform.forward, out hit,
                _player.Weapon.Range);
        }

        private void HandleHitToZombie(in RaycastHit hit)
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                hit.collider.GetComponent<Zombie>().GetDamage(_player);
            }
        }

        private IEnumerator WaitForCooldown()
        {
            _isCooldownActive = true;
            yield return new WaitForSeconds(_player.Weapon.CooldownAttack);
            _isCooldownActive = false;
        }

        private void OnEnable()
        {
            _mouseService.OnMousePressed += AttackZombies;
        }

        private void OnDisable()
        {
            _mouseService.OnMousePressed -= AttackZombies;
        }
    }
}