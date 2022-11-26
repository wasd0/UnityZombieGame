using Zenject;

namespace Infrastructure.Installers
{
    public class DontDestroyInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindInput();
        }

        private void BindInput()
        {
            Container.
                Bind<PlayerInput>().
                FromNew().
                AsSingle().
                NonLazy();
        }
    }
}