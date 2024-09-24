using System.Collections.Generic;
using System.Linq;
using Game.Data;
using Game.Player;
using Game.StateMachine.States;

namespace Game.StateMachine
{
    public class GameStateMachine : IStateSwitcher
    {
        private List<IState> _states;
        private IState _currentState;
        private GameData _gameData;
        private PlayerMove _playerMove;
        private PlayerAnimatorController _playerAnimatorController;

        public GameStateMachine(GameData gameData, PlayerAnimatorController playerAnimatorController, PlayerMove playerMove)
        {
            _gameData = gameData;
            _playerMove = playerMove;
            _playerAnimatorController = playerAnimatorController;
            _states = new List<IState>()
            {
                new PrepareState(_playerAnimatorController, _gameData, this),
                new GameState(_playerAnimatorController.gameObject, this, _playerMove, _playerAnimatorController, gameData)
            };
            _currentState = _states[0];
            _currentState.Enter();
        }

        public void SwitchState<T>() where T : IState
        {
            var state = _states.FirstOrDefault(state => state is T);
            _currentState.Exit();
            _currentState = state;
            _currentState?.Enter();
        }
    }
}