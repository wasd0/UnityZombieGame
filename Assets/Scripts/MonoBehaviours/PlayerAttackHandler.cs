using System.Collections;
using Entities;
using Services;
using UnityEngine;
using Zenject;

namespace MonoBehaviours
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

        private void Attack()
        {
            bool isHit = TryGetHit(out var ray);
            if (!_isCooldownActive && isHit)
            {
                SentDamage(ray);
                StartCoroutine(WaitForCooldown());
            }
        }

        private bool TryGetHit(out RaycastHit hit)
        {
            Transform playerTransform = _player.transform;
            return Physics.Raycast(playerTransform.position, playerTransform.forward, out hit,
                _player.Weapon.Range);
        }

        private void SentDamage(in RaycastHit hit)
        {
            var damageable = hit.collider.GetComponent<IDamageable>();

            damageable?.ApproveDamage(_player);
        }

        private IEnumerator WaitForCooldown()
        {
            _isCooldownActive = true;
            yield return new WaitForSeconds(_player.Weapon.CooldownAttack);
            _isCooldownActive = false;
        }

        private void OnEnable()
        {
            _mouseService.OnClicked += Attack;
        }

        private void OnDisable()
        {
            _mouseService.OnClicked -= Attack;
        }
    }
}