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
        private PlayerMove _playerMove;
        private PlayerViewChanger _playerViewChanger;
        public void Initialize()
        {
            _stateMachine = new GameStateMachine(_gameData, _playerViewChanger, _playerMove);
        }

        public GameEntryPoint(GameData gameData, PlayerViewChanger playerViewChanger, PlayerMove playerMove)
        {
            _gameData = gameData;
            _playerMove = playerMove;
            _playerViewChanger = playerViewChanger;
        }
    }
}