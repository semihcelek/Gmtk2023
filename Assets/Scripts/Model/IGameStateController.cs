namespace SemihCelek.Gmtk2023.Model
{
    public interface IGameStateController
    {
        GameState GameState { get; }

        void AddState(GameState gameState);
        void RemoveState(GameState gameState);
    }
}