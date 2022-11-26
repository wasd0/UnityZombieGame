using Entities.Enemy;
using Factories;
using Factories.Components;
using Services;
using UnityEngine;
using UnityObjects;
using Zenject;

namespace Infrastructure.Installers
{
    public class LocationInstaller : MonoInstaller
    {
        [SerializeField] private Transform _playerSpawnPosition;
        [SerializeField] private Transform _zombieSpawnPosition;

        public override void InstallBindings()
        {
            BindPlayerSpawnPosition();
            BindZombieSpawnPosition();
            BindPlayer();
            BindZombie();
        }

        private void BindPlayerSpawnPosition()
        {
            Container.Bind<PlayerSpawnPosition>().
                AsSingle().
                WithArguments(_playerSpawnPosition);
        }
        
        private void BindZombieSpawnPosition()
        {
            Container.Bind<ZombieSpawnPosition>().
                AsSingle().
                WithArguments(_zombieSpawnPosition);
        }

        private void BindPlayer()
        {
            Container.
                Bind<Player>().
                FromFactory<PlayerFactory>().
                AsSingle().
                NonLazy();
        }

        private void BindZombie()
        {
            Container.
                Bind<Zombie>().
                FromFactory<ZombieFactory>().
                AsSingle().
                NonLazy();
        }
    }
}