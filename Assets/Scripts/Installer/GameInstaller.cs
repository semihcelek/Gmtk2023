using SemihCelek.Gmtk2023.AbilityModule.Controller;
using SemihCelek.Gmtk2023.AbilityModule.Factory;
using SemihCelek.Gmtk2023.AbilityModule.Model;
using SemihCelek.Gmtk2023.Controller;
using SemihCelek.Gmtk2023.Model;
using SemihCelek.Gmtk2023.PlayerModule.Controller;
using SemihCelek.Gmtk2023.PlayerModule.View;
using UnityEngine.Rendering;
using Zenject;

namespace SemihCelek.Gmtk2023.Installer
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<PlayerView>().FromComponentInHierarchy().AsSingle();
            
            InstallControllers();
            InstallFactories();
        }

        private void InstallControllers()
        {
            Container.Bind<IGameStateController>().To<GameStateController>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<AbilityController>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<GameInputController>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<PlayerController>().AsSingle().NonLazy();
        }

        private void InstallFactories()
        {
            Container.BindFactory<AbilityType, IAbilityView, IAbilityView.Factory>().FromFactory<AbilityViewFactory>();
            Container.BindFactory<AbilityContainer, AbilityContainer.Factory>().AsSingle();
        }
    }
}