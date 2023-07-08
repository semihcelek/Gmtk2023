using System;
using Cysharp.Threading.Tasks;
using SemihCelek.Gmtk2023.Config;
using SemihCelek.Gmtk2023.Model;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace SemihCelek.Gmtk2023.Controller
{
    public class AIInputController : IGameInput, ITickable
    {
        private IGameStateController _gameStateController;

        private DifficultyController _difficultyController;

        private bool _isLocked;

        private float _interval;

        public float HorizontalInput { get; private set; }

        public float VerticalInput { get; private set; }

        public event Action<bool> OnPrimaryExecute;

        public event Action<bool> OnSecondaryExecute;

        public AIInputController(IGameStateController gameStateController, DifficultyController difficultyController)
        {
            _gameStateController = gameStateController;
            _difficultyController = difficultyController;
        }

        public void Tick()
        {
            _interval += Time.deltaTime * 1000f;
            
            if (_isLocked || (_gameStateController.GameState & GameState.Locked) != 0)
            {
                return;
            }

            if (_interval < GameInputTimeIntervalConfig.AI_EXECUTE_RATE_LIMIT_MILLISECOND)
            {
                return;
            }
            _interval = 0;
            
            GenerateExecuteInputs();
            GenerateAxisInputs();
        }

        private void GenerateAxisInputs()
        {
            HorizontalInput = Random.Range(-1f, 1f);
            VerticalInput = Random.Range(-1f, 1f);
        }

        private void GenerateExecuteInputs()
        {
            bool canExecute = Random.Range(-1f, 1f) > 0;
            if (!canExecute)
            {
                return;
            }

            RandomExecuteAsync().Forget();
        }

        private async UniTaskVoid RandomExecuteAsync()
        {
            OnPrimaryExecute?.Invoke(true);

            await UniTask.Delay(Random.Range(0,1600));
            
            OnPrimaryExecute?.Invoke(false);
        }
    }
}