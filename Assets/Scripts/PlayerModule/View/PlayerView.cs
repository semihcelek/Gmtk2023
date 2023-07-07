using System;
using Gum.Composer;
using Gum.Composer.Unity.Runtime;
using SemihCelek.Gmtk2023.Model;
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
        
        private bool _isLocked;

        private void OnEnable()
        {
            ListenEvents();
        }

        private void ListenEvents()
        {
            _gameInput.OnPrimaryExecute += PlayPrimarySkill;
        }

        private void PlayPrimarySkill()
        {
            Debug.Log("lann");
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
            transform.position += horizontalInput * Time.deltaTime * Vector3.right;
            
            transform.localScale = horizontalInput > 0f 
                ? Vector3.one 
                : new Vector3(-1f, 1f, 1f);
        }

        protected override IAspect[] GetAspects()
        {
            // throw new NotImplementedException();
            return Array.Empty<IAspect>();
        }

        private void UnsubscribeFromEvents()
        {
            _gameInput.OnPrimaryExecute -= PlayPrimarySkill;
        }

        private void OnDisable()
        {
            UnsubscribeFromEvents();
        }
    }
}