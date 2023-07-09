using System;
using Gum.Composer;
using Gum.Composer.Generated;
using Gum.Composer.Unity.Runtime;
using SemihCelek.Gmtk2023.Model;
using SemihCelek.Gmtk2023.PlayerModule.Controller;
using UnityEngine;
using Zenject;

namespace SemihCelek.Gmtk2023.PlayerModule.View
{
    public class PlayerView : MonoComposable
    {
        [Inject]
        private IGameStateController _gameStateController;

        [Inject]
        private IGameInput _gameInput;

        [Inject]
        private PlayerController _playerController;

        [Inject]
        public Vector3 pivotPosition;
        
        private bool _isLocked;

        private bool _isExecutingPrimarySkill;
        private bool _isExecutingSecondarySkill;

        private void OnEnable()
        {
            ListenEvents();
        }

        private void ListenEvents()
        {
            _gameInput.OnPrimaryExecute += ExecutePrimarySkill;
        }

        private void ExecutePrimarySkill(bool keyDown)
        {
            _isExecutingPrimarySkill = keyDown;

            _playerController.ExecutePrimarySkill(keyDown);
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
            
            transform.position += horizontalInput * Time.deltaTime * Vector3.right * Composition.GetAspect<SpeedAspect>().Value;
            transform.localScale = horizontalInput > 0f 
                ? Vector3.one 
                : new Vector3(-1f, 1f, 1f);
        }

        private void UnsubscribeFromEvents()
        {
            _gameInput.OnPrimaryExecute -= ExecutePrimarySkill;
        }

        private void OnDisable()
        {
            UnsubscribeFromEvents();
        }

        protected override IAspect[] GetAspects()
        {
            return Array.Empty<IAspect>();
        }
    }
}