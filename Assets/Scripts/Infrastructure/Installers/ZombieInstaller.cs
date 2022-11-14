using Services;
using Zenject;

namespace Infrastructure.Installers
{
    public class ZombieInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindMovementService();
        }

        private void BindMovementService()
        {
            Container.
                Bind<IMovementService<Zombie>>().
                To<WalkMovementService<Zombie>>().
                AsSingle().
                NonLazy();
        }
    }
}