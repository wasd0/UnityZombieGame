using UnityEngine;
using Zenject;
using IInitializable = Zenject.IInitializable;

namespace Installers
{
    public class LocationInstaller : MonoInstaller, IInitializable
    {
        [SerializeField] private Transform _playerSpawnPoint;

        public override void InstallBindings()
        {
            BindPlayerSpawnPosition();
            BindPlayer();
        }

        private void BindPlayerSpawnPosition()
        {
            Container.Bind<SpawnPosition>().
                WithId(SpawnPosition.Markers.Player).
                AsSingle().
                WithArguments(_playerSpawnPoint);
        }

        private void BindPlayer()
        {
            Container.
                Bind<PlayerEntity>().
                FromFactory<PlayerFactory>().
                AsSingle().
                NonLazy();
        }

        public void Initialize() //TODO: убрать инициалайз и закинуть в SceneBootstrap.cs
        {
            var playerFactory = Container.Resolve<PlayerFactory>();
            playerFactory.CreateFromSpawnPosition();
        }
    }
}