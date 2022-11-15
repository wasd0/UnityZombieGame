using Services;
using Zenject;

namespace Infrastructure.Installers
{
    public class PlayerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindMovementService();
        }

        private void BindMovementService()
        {
            Container.
                Bind<IMovementService<Player>>().
                To<WalkMovementService<Player>>().
                AsSingle().
                NonLazy();
        }
    }
}