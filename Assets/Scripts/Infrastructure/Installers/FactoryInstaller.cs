using Factories;
using Zenject;

namespace Infrastructure.Installers
{
    public class FactoryInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ZombieFactory>().AsCached();
            Container.Bind<PlayerFactory>().AsCached();
        }
    }
}