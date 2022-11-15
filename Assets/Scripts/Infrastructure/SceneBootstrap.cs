using System;
using Factories;
using UnityEngine;
using Zenject;

namespace Infrastructure
{
    public class SceneBootstrap : MonoBehaviour
    {
        private PlayerFactory _playerFactory;
        private ZombieFactory _zombieFactory;

        [Inject]
        private void Construct(ZombieFactory zombieFactory)
        {
            _zombieFactory = zombieFactory;
        }

        private void Update()
        {
            if (Input.GetKeyUp(KeyCode.C))
                _zombieFactory.Create();
        }
    }
}