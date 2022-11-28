using Services;
using UnityObjects;
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
                Bind<MouseService>().
                FromNew().
                AsSingle().
                NonLazy();
        }

        private void BindPlayerInput()
        {
            Container.
                Bind<PlayerInput>().
                FromNew().
                AsSingle().
                NonLazy();
        }
    }
}