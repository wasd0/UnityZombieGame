using Services;
using Zenject;

namespace Infrastructure.Installers
{
    public class PlayerInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindPlayerMovementService();
        }

        private void BindPlayerMovementService()
        {
            Container.
                Bind<IMovementService<Player>>().
                To<WalkMovementService<Player>>().
                AsSingle().
                NonLazy();
        }
    }
}