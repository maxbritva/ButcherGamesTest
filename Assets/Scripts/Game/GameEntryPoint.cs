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
        private PlayerAnimatorController _playerAnimatorController;
        public void Initialize()
        {
            _stateMachine = new GameStateMachine(_gameData, _playerAnimatorController, _playerMove);
        }

        public GameEntryPoint(GameData gameData, PlayerAnimatorController playerAnimatorController, PlayerMove playerMove)
        {
            _gameData = gameData;
            _playerMove = playerMove;
            _playerAnimatorController = playerAnimatorController;
        }
    }
}