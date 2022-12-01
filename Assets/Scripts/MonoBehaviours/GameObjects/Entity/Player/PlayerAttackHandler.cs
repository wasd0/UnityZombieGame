using System.Collections;
using Entities.Interfaces;
using Services;
using UnityEngine;
using Zenject;

namespace MonoBehaviours.GameObjects.Entity.Player
{
    [RequireComponent(typeof(Entities.Neutral.Player))]
    public class PlayerAttackHandler : MonoBehaviour
    {
        private Entities.Neutral.Player _player;
        private bool _isCooldownActive;
        private MouseService _mouseService;

        [Inject]
        private void Construct(MouseService mouseService)
        {
            _mouseService = mouseService;
        }

        private void Awake()
        {
            _player = GetComponent<Entities.Neutral.Player>();
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
                _player.Weapon.Preset.Range);
        }

        private void SentDamage(in RaycastHit hit)
        {
            var damageable = hit.collider.GetComponent<IDamageable>();

            damageable?.ApproveDamage(_player);
        }

        private IEnumerator WaitForCooldown()
        {
            _isCooldownActive = true;
            yield return new WaitForSeconds(_player.Weapon.Preset.AttackRate);
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