using SemihCelek.Gmtk2023.Model;
using Zenject;

namespace SemihCelek.Gmtk2023.Controller
{
    public class GameInputController : ITickable
    {
        private readonly IGameStateController _gameStateController;

        public GameInputController(IGameStateController gameStateController)
        {
            _gameStateController = gameStateController;
        }

        public void Tick()
        {
            if (_gameStateController.GameState.HasFlag(GameState.Locked))
            {
                return;
            }
            
            ReceiveInput();
        }

        private void ReceiveInput()
        {
            
        }
    }
}