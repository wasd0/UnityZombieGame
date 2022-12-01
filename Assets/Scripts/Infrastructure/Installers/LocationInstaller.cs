using Entities;
using Entities.Enemy;
using Entities.Neutral;
using Factories;
using Factories.Components;
using MonoBehaviours;
using MonoBehaviours.GameObjects.Camera;
using UnityEngine;
using Zenject;

namespace Infrastructure.Installers
{
    public class LocationInstaller : MonoInstaller
    {
        [SerializeField] private Transform _playerSpawnPosition;
        [SerializeField] private Transform _zombieSpawnPosition;
        [SerializeField] private CameraFollow _camera;

        public override void InstallBindings()
        {
            BindPlayerSpawnPosition();
            BindZombieSpawnPosition();
            BindCamera();
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

        private void BindCamera()
        {
            Container.
                Bind<CameraFollow>().
                FromInstance(_camera).
                AsSingle().NonLazy();
        }
    }
}