using System;
using SemihCelek.Gmtk2023.Config;
using SemihCelek.Gmtk2023.Model;
using UnityEngine;
using Zenject;

namespace SemihCelek.Gmtk2023.Controller
{
    public class GameInputController : IGameInput, ITickable
    {
        private readonly IGameStateController _gameStateController;
        
        public float HorizontalInput { get; private set; }

        public float VerticalInput { get; private set; }
        
        public event Action<bool> OnPrimaryExecute;
        public event Action<bool> OnSecondaryExecute;

        private float _lastReceivedExecuteInputTime;

        private KeyCode _currentExecuteKeyCode;

        public GameInputController(IGameStateController gameStateController)
        {
            _gameStateController = gameStateController;
        }

        public void Tick()
        {
            float lastReceivedExecuteInputTime = Time.deltaTime * 1000;
            _lastReceivedExecuteInputTime += lastReceivedExecuteInputTime;
            
            if (_gameStateController.GameState.HasFlag(GameState.Locked))
            {
                return;
            }
            
            CheckAxisInputs();

            if (_lastReceivedExecuteInputTime < GameInputTimeIntervalConfig.EXECUTE_RATE_LIMIT_MILLISECOND)
            {
                return;
            }
            
            CheckExecuteInputs();
        }

        private void CheckAxisInputs()
        {
            HorizontalInput = Input.GetAxisRaw("Horizontal");
            VerticalInput = Input.GetAxisRaw("Vertical");
        }

        private void CheckExecuteInputs()
        {
            bool isPrimaryOnUse = CheckForKeyInput(GameInputConfig.PRIMARY_EXECUTE_KEY_CODE, PrimaryExecute);
            if (isPrimaryOnUse)
            {
                _lastReceivedExecuteInputTime = 0;
                return;
            }

            bool isSecondaryOnUse = CheckForKeyInput(GameInputConfig.SECONDARY_EXECUTE_KEY_CODE, SecondaryExecute);
            if (isSecondaryOnUse)
            {
                _lastReceivedExecuteInputTime = 0;
                return;
            }
        }

        private bool CheckForKeyInput(KeyCode keyCode, Action<bool> callback)
        {
            bool isKeyDown = Input.GetKeyDown(keyCode);
            bool isKeyUp = Input.GetKeyUp(keyCode);
            bool isKeyHolding = Input.GetKey(keyCode);

            if (isKeyUp && keyCode == _currentExecuteKeyCode)
            {
                callback?.Invoke(false);
                return false;
            }

            if (isKeyDown)
            {
                _currentExecuteKeyCode = keyCode;
                
                callback?.Invoke(true);
                return true;
            }

            return false;
        }
        

        private void PrimaryExecute(bool value) => OnPrimaryExecute?.Invoke(value);
        private void SecondaryExecute(bool value) => OnSecondaryExecute?.Invoke(value);
    }
}