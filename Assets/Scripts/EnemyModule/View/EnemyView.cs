using Gum.Composer;
using Gum.Composer.Generated;
using SemihCelek.Gmtk2023.AbilityModule.Controller;
using SemihCelek.Gmtk2023.EnemyModule.Controller;
using SemihCelek.Gmtk2023.Model;
using UnityEngine;
using Zenject;
using AspectType = Gum.Composer.Generated.AspectType;

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
        
        [Inject]
        private IGameStateController _gameStateController;

        public Composition EnemyComposition;

        private AbilityContainer _abilityContainer;
        
        private GameObject _visualGameObject;
        
        private bool _isLocked;
        
        private bool _executingPrimarySkill;
        
        private bool _isMirroringLocked;

        public void Construct(Composition composition)
        {
            EnemyComposition = composition;

            SetupEnemyVisuals();
            SetupEnemyAbilities();
            
            ListenEvents();
        }

        private void ListenEvents()
        {
            _gameInput.OnPrimaryExecute += ExecutePrimarySkill;
        }
        
        private void ExecutePrimarySkill(bool keyDown)
        {
            _executingPrimarySkill = keyDown;

            _abilityController.ProcessAbility(_abilityContainer[EnemyComposition.GetAspect<AbilityAspect>().Value],
                keyDown);
        }
        
        private void SetupEnemyVisuals()
        {
            _visualGameObject =
                Instantiate(EnemyComposition.GetAspect<GameObjectAspect>().Value, transform);

            _isMirroringLocked = EnemyComposition.HasAspect(LockedRotationAspect.ASPECT_TYPE);
        }

        private void SetupEnemyAbilities()
        {
            _abilityContainer = _abilityContainerFactory.Create();

            _abilityController.SetupAbilities(
                _abilityContainer,
                EnemyComposition.GetAspect<AbilityAspect>().Value,
                transform);
        }
        
        private void Update()
        {
            if (_isLocked || (_gameStateController.GameState & GameState.Locked) != 0)
            {
                return;
            }

            ApplyMovement();
        }

        private void ApplyMovement()
        {
            float horizontalInput = _gameInput.HorizontalInput;
            if (horizontalInput == 0f)
            {
                return;
            }            
            
            transform.position += horizontalInput * Time.deltaTime * Vector3.right * 2;

            if (_isMirroringLocked)
            {
                return;
            }

            transform.localScale = horizontalInput > 0f 
                ? Vector3.one 
                : new Vector3(-1f, 1f, 1f);
        }

        private void UnsubscribeFromEvents()
        {
            _gameInput.OnPrimaryExecute -= ExecutePrimarySkill;
        }

        private void OnDestroy()
        {
            UnsubscribeFromEvents();
        }

        public class Factory : PlaceholderFactory<Composition, Transform, EnemyView> { }
    }
}