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
        
        public event Action OnPrimaryExecute;
        public event Action OnSecondaryExecute;

        private float _lastReceivedExecuteInputTime;

        public GameInputController(IGameStateController gameStateController)
        {
            _gameStateController = gameStateController;
        }

        public void Tick()
        {
            _lastReceivedExecuteInputTime += Time.deltaTime * 1000;
            
            if (_gameStateController.GameState.HasFlag(GameState.Locked))
            {
                return;
            }
            
            CheckAxisInputs();

            if (_lastReceivedExecuteInputTime < GameInputTimeIntervalConfig.EXECUTE_RATE_LIMIT_MILLISECOND)
            {
                return;
            }

            _lastReceivedExecuteInputTime = 0;
                
            CheckExecuteInputs();
        }

        private void CheckAxisInputs()
        {
            HorizontalInput = Input.GetAxisRaw("Horizontal");
            VerticalInput = Input.GetAxisRaw("Vertical");
        }

        private void CheckExecuteInputs()
        {
            if (Input.GetKeyUp(GameInputConfig.PRIMARY_EXECUTE_KEY_CODE))
            {
                OnPrimaryExecute?.Invoke();
                return;
            }
            
            if (Input.GetKeyUp(GameInputConfig.SECONDARY_EXECUTE_KEY_CODE))
            {
                OnSecondaryExecute?.Invoke();
            }
        }
    }
}