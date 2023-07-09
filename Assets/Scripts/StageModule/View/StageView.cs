using Gum.Composer.Generated;
using SemihCelek.Gmtk2023.EnemyModule.Controller;
using SemihCelek.Gmtk2023.EnemyModule.View;
using SemihCelek.Gmtk2023.LevelModule.View;
using UnityEngine;
using Zenject;

namespace SemihCelek.Gmtk2023.StageModule.View
{
    public class StageView : MonoBehaviour
    {
        [Inject]
        private EnemySpawnPointView[] _enemySpawnPointViews;

        [Inject]
        private Transform _enemyParentTransform;
        
        [Inject]
        private EnemySpawner _enemySpawner;

        private EnemyView[] _enemyViews;
        
        public void InitializeStage()
        {
            ToggleStage(true);
            
            SpawnEnemies();
        }

        private void SpawnEnemies()
        {
            EnemyView[] enemyViews = new EnemyView[_enemySpawnPointViews.Length];
            for (int index = 0; index < _enemySpawnPointViews.Length; index++)
            {
                EnemySpawnPointView enemySpawnPointView = _enemySpawnPointViews[index];
                
                enemyViews[index] = _enemySpawner.SpawnEnemyAtPosition(enemySpawnPointView.EnemyAssetData,
                    _enemyParentTransform, enemySpawnPointView.Composition.GetAspect<PositionAspect>().Value);
            }
        }

        public void FinalizeStage()
        {
            ToggleStage(false);
        }

        private void ToggleStage(bool value)
        {
            gameObject.SetActive(value);
        }
    }
}