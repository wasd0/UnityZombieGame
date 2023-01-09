using Services.Implementations;
using Services.Interfaces;
using Zenject;

namespace Infrastructure.Installers
{
    public class DontDestroyInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindPlayerInput();
            BindMouseHandler();
        }

        private void BindMouseHandler()
        {
            Container.
                Bind<ILookInputService>().
                To<MouseLookInputService>().
                AsSingle().
                NonLazy();
        }

        private void BindPlayerInput()
        {
            Container.
                Bind<PlayerInput>().
                FromNew().
                AsSingle();
        }
    }
}