using Services;
using Zenject;

namespace Infrastructure
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