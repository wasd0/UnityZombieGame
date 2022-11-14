using Factories;
using Zenject;

namespace Infrastructure
{
    public class SceneBootstrap : IInitializable
    {
        private readonly PlayerFactory _playerFactory = new PlayerFactory();
        private readonly ZombieFactory _zombieFactory = new ZombieFactory();
    
        public void Initialize()
        {
            _playerFactory.Create();
            _zombieFactory.Create();
        }
    }
}