using Factories;
using Zenject;

namespace Infrastructure
{
    public class SceneBootstrap : IInitializable
    {
        private readonly PlayerFactory _playerFactory = new PlayerFactory();
    
        public void Initialize()
        {
            _playerFactory.CreatePlayer();
        }
    }
}