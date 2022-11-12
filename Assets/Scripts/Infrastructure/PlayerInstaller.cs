using Zenject;

namespace Installers
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
                Bind<IMovementService>().
                To<WalkMovementService>().
                AsSingle().
                NonLazy();
        }
    }
}