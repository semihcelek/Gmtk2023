using Gum.Composer;
using SemihCelek.Gmtk2023.AbilityModule.Controller;
using SemihCelek.Gmtk2023.AbilityModule.Factory;
using SemihCelek.Gmtk2023.AbilityModule.Model;
using SemihCelek.Gmtk2023.Controller;
using SemihCelek.Gmtk2023.EnemyModule.Controller;
using SemihCelek.Gmtk2023.EnemyModule.Factory;
using SemihCelek.Gmtk2023.EnemyModule.Model;
using SemihCelek.Gmtk2023.EnemyModule.View;
using SemihCelek.Gmtk2023.LevelModule.View;
using SemihCelek.Gmtk2023.Model;
using SemihCelek.Gmtk2023.PlayerModule.Controller;
using SemihCelek.Gmtk2023.PlayerModule.View;
using SemihCelek.Gmtk2023.StageModule.Controller;
using SemihCelek.Gmtk2023.StageModule.View;
using UnityEngine;
using UnityEngine.Rendering;
using Zenject;

namespace SemihCelek.Gmtk2023.Installer
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField]
        private StageView[] _gameStageViews;
        
        public override void InstallBindings()
        {
            Container.Bind<PlayerView>().FromComponentInHierarchy().AsSingle().NonLazy();
            Container.BindInstance(_gameStageViews).AsSingle().NonLazy();
            
            InstallControllers();
            InstallFactories();
            InstallSignals();
        }

        private void InstallControllers()
        {
            Container.Bind<IGameStateController>().To<GameStateController>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<AbilityController>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<PlayerController>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<GameInputController>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<DifficultyController>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<EnemySpawner>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<EnemyController>().AsSingle().NonLazy();
            Container.BindInterfacesAndSelfTo<StageController>().AsSingle().NonLazy();
        }

        private void InstallFactories()
        {
            Container.BindFactory<AbilityType, IAbilityView, IAbilityView.Factory>().FromFactory<AbilityViewFactory>().NonLazy();
            Container.BindFactory<AbilityContainer, AbilityContainer.Factory>().AsSingle();
            Container.BindFactory<Composition, Transform, EnemyView, EnemyView.Factory>()
                .FromFactory<EnemyViewFactory>().NonLazy();
        }

        private void InstallSignals()
        {
            SignalBusInstaller.Install(Container);
        }
    }
}