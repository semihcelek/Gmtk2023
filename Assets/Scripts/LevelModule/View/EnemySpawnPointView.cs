using Gum.Composer;
using Gum.Composer.Generated;
using Gum.Composer.Unity.Runtime;
using SemihCelek.Gmtk2023.EnemyModule.Model;
using SemihCelek.Gmtk2023.Model;
using UnityEngine;

namespace SemihCelek.Gmtk2023.LevelModule.View
{
    public class EnemySpawnPointView : MonoComposable
    {
        [SerializeField]
        private EnemyAssetData _enemyAssetData;

        [SerializeField]
        private Difficulty _difficulty;
        
        private Vector3 SpawnPoint => transform.position;

        public EnemyAssetData EnemyAssetData => _enemyAssetData;
        
        protected override IAspect[] GetAspects()
        {
            return new IAspect[] { new DifficultyAspect(_difficulty), new PositionAspect(SpawnPoint) };
        }
    }
}