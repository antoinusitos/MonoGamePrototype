namespace MonoGamePrototype.Engine
{
    public class GameManager : Manager
    {
        public static GameManager instance { get; private set; } = null;

        public enum GameState
        {
            MENU,
            GAME,
            PAUSE,
            LEVELEDITOR,
        }

        public GameState currentGameState { get; private set; } = GameState.MENU;

        public override void Initialize()
        {
            instance = this;
        }

        public void SetGameState(GameState gameState)
        {
            currentGameState = gameState;
        }
    }
}
