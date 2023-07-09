using SemihCelek.Gmtk2023.EnemyModule.Model;
using SemihCelek.Gmtk2023.EnemyModule.View;
using SemihCelek.Gmtk2023.Model;
using UnityEngine;

namespace SemihCelek.Gmtk2023.EnemyModule.Controller
{
    public class EnemySpawner : IController
    {
        private EnemyView.Factory _enemyFactory;

        public EnemySpawner(EnemyView.Factory enemyFactory)
        {
            _enemyFactory = enemyFactory;
        }

        public EnemyView SpawnEnemyAtPosition(EnemyAssetData enemyAssetData, Transform parentTransform)
        { 
            return _enemyFactory.Create(enemyAssetData.GetComposition(), parentTransform);
        }
        
        public EnemyView[] SpawnEnemyMultipleAtPosition(EnemyAssetData enemyAssetData, Transform parentTransform, int count)
        {
            EnemyView[] enemyViews = new EnemyView[count];
            for (int index = 0; index < count; index++)
            {
                enemyViews[index] = _enemyFactory.Create(enemyAssetData.GetComposition(), parentTransform);
            }

            return enemyViews;
        }
    }
}