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
        private PlayerViewChanger _playerViewChanger;

        public GameStateMachine(GameData gameData, PlayerViewChanger playerViewChanger, PlayerMove playerMove)
        {
            _gameData = gameData;
            _playerMove = playerMove;
            _playerViewChanger = playerViewChanger;
            _states = new List<IState>()
            {
                new PrepareState(_playerViewChanger, _gameData, this),
                new GameState(_playerViewChanger.gameObject, this, _playerMove)
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