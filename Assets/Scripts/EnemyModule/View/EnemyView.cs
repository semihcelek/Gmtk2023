using System;
using Gum.Composer;
using Gum.Composer.Generated;
using Gum.Composer.Unity.Runtime;
using SemihCelek.Gmtk2023.AbilityModule.Controller;
using SemihCelek.Gmtk2023.EnemyModule.Controller;
using SemihCelek.Gmtk2023.Model;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace SemihCelek.Gmtk2023.EnemyModule.View
{
    public class EnemyView : MonoBehaviour
    {
        [Inject]
        private IGameInput _gameInput;

        [Inject]
        private EnemyController _enemyController;

        [Inject]
        private AbilityContainer.Factory _abilityContainerFactory;

        [Inject]
        private AbilityController _abilityController;

        public Composition EnemyComposition;

        private AbilityContainer _abilityContainer;

        public void Construct(Composition composition)
        {
            EnemyComposition = composition;

            SetupEnemyVisuals();
            SetupEnemyAbilities();
        }

        private void SetupEnemyVisuals()
        {
             GameObject visualGameObject =Object.Instantiate(EnemyComposition.GetAspect<GameObjectAspect>().Value, transform);
        }

        private void SetupEnemyAbilities()
        {
            _abilityContainer = _abilityContainerFactory.Create();

            _abilityController.SetupAbilities(
                _abilityContainer,
                EnemyComposition.GetAspect<AbilityAspect>().Value,
                transform);
        }

        public class Factory : PlaceholderFactory<Composition, Transform, EnemyView> { }
    }
}