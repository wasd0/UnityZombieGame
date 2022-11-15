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
        private void Construct(ZombieFactory zombieFactory, PlayerFactory playerFactory)
        {
            _zombieFactory = zombieFactory;
            _playerFactory = playerFactory;
        }

        private void Update()
        {
            if (Input.GetKeyUp(KeyCode.C))
                _zombieFactory.Create();
            else if (Input.GetKeyUp(KeyCode.X))
                _playerFactory.Create();
        }
    }
}