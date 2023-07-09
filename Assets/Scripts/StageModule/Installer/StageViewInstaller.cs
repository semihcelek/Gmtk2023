using SemihCelek.Gmtk2023.LevelModule.View;
using UnityEngine;
using Zenject;

namespace SemihCelek.Gmtk2023.StageModule.Installer
{
    public class StageViewInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<EnemySpawnPointView[]>().FromMethod(GetEnemySpawnPointViews);

            Container.Bind<Transform>().FromComponentOn(gameObject).AsSingle().NonLazy();
        }

        private EnemySpawnPointView[] GetEnemySpawnPointViews() => GetComponentsInChildren<EnemySpawnPointView>();
    }
}