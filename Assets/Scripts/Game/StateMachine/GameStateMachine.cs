using System.Collections.Generic;
using System.Linq;
using Game.StateMachine.States;

namespace Game.StateMachine
{
    public class GameStateMachine : IStateSwitcher
    {
        private List<IState> _states;
        private IState _currentState;
        
        public GameStateMachine()
        {
            _states = new List<IState>()
            {
                 new PrepareState(),
                 new GameState()
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