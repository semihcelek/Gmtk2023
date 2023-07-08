using Gum.Composer;
using SemihCelek.Gmtk2023.EnemyModule.Model;
using SemihCelek.Gmtk2023.EnemyModule.View;
using UnityEngine;
using Zenject;

namespace SemihCelek.Gmtk2023.EnemyModule.Factory
{
    public class EnemyViewFactory : IFactory<Composition, Transform, EnemyView>
    {
        private IInstantiator _instantiator;

        private const string ENEMY_PREFAB_NAME = "Prefabs/Enemy";

        public EnemyViewFactory(IInstantiator instantiator)
        {
            _instantiator = instantiator;
        }

        public EnemyView Create(Composition composition, Transform parentTransform)
        {
            EnemyView enemyView = _instantiator.InstantiatePrefabResourceForComponent<EnemyView>(ENEMY_PREFAB_NAME, parentTransform);

            enemyView.transform.localPosition = Vector3.zero; 
            
            enemyView.Construct(composition);
            
            return enemyView;
        }
    }
}