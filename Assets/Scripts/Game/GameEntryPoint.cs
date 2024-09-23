using Game.Data;
using Game.Player;
using Game.StateMachine;
using VContainer.Unity;

namespace Game
{
    public class GameEntryPoint: IInitializable
    {
        private GameStateMachine _stateMachine;
        private GameData _gameData;
        private PlayerViewChanger _playerViewChanger;
        public void Initialize()
        {
            _stateMachine = new GameStateMachine(_gameData, _playerViewChanger);
        }

        public GameEntryPoint(GameData gameData, PlayerViewChanger playerViewChanger)
        {
            _gameData = gameData;
            _playerViewChanger = playerViewChanger;
        }
    }
}