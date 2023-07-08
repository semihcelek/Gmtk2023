using SemihCelek.Gmtk2023.EnemyModule.Model;
using SemihCelek.Gmtk2023.EnemyModule.View;
using SemihCelek.Gmtk2023.LevelModule.View;
using SemihCelek.Gmtk2023.Model;
using Zenject;

namespace SemihCelek.Gmtk2023.EnemyModule.Controller
{
    public class EnemySpawner : IController, IInitializable
    {
        [Inject]
        private SpawnPointView _spawnPointView;

        [Inject]
        private EnemyAssetData _enemyAssetData;

        [Inject]
        private EnemyView.Factory _enemyFactory;
        
        public void Initialize()
        {
            EnemyView enemyView = _enemyFactory.Create(_enemyAssetData.GetComposition(), _spawnPointView.transform);
        }
    }
}