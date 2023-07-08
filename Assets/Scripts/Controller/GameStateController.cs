using SemihCelek.Gmtk2023.Model;
using SemihCelek.Gmtk2023.Utility;

namespace SemihCelek.Gmtk2023.Controller
{
    public class GameStateController : IGameStateController, IController
    {
        public GameState GameState { get; private set; }

        public void AddState(GameState gameState)
        {
            if (GameState.HasFlag(gameState))
            {
                return;
            }

            GameState = GameState.AddFlag(gameState);
        }

        public void RemoveState(GameState gameState)
        {
            if (!GameState.HasFlag(gameState))
            {
                return;
            }

            GameState = GameState.RemoveFlag(gameState);
        }
    }
}