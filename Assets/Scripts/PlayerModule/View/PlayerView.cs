using SemihCelek.Gmtk2023.Model;
using UnityEngine;
using Zenject;

namespace SemihCelek.Gmtk2023.PlayerModule.View
{
    public class PlayerView : MonoBehaviour
    {
        [Inject]
        private IGameStateController _gameStateController;

        [Inject]
        private IGameInput _gameInput;
        
        [Inject]
        private Transform _itemParentTransform;
        
        private bool _isLocked;

        private void OnEnable()
        {
            ListenEvents();
        }

        private void ListenEvents()
        {
            _gameInput.OnPrimaryExecute += ExecutePrimarySkill;
        }

        private void ExecutePrimarySkill()
        {
            GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
            go.transform.SetParent(_itemParentTransform);
            go.transform.localPosition = Vector3.zero;
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
            transform.position += horizontalInput * Time.deltaTime * Vector3.right * 2.2f;
            
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
    }
}