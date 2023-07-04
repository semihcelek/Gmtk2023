using SemihCelek.Gmtk2023.Controller;
using SemihCelek.Gmtk2023.Model;
using Zenject;

namespace SemihCelek.Gmtk2023.Installer
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<IGameStateController>().To<GameStateController>().AsSingle().NonLazy();
            
            Container.BindInterfacesTo<GameInputController>().AsSingle().NonLazy();
        }
    }
}