using Factories;
using UnityEngine;
using Zenject;

namespace Infrastructure
{
    public class LocationInstaller : MonoInstaller
    {
        [SerializeField] private GameObject _zombiePrefab;
        [SerializeField] private Transform _playerSpawnPoint;

        public override void InstallBindings()
        {
            BindPlayerSpawnPosition();
            BindPlayer();
            BindZombie();
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
                Bind<Player>().
                FromFactory<PlayerFactory>().
                AsSingle().
                NonLazy();
        }

        public void BindZombie()
        {
            //TODO: Создать фабрбику зомби
            Container.
                Bind<Zombie>().
                FromNewComponentOnNewPrefab(_zombiePrefab).
                AsSingle().
                NonLazy();
        }
    }
}