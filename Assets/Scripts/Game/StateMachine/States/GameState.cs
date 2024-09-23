using Game.Player;
using UnityEngine;

namespace Game.StateMachine.States
{
    public class GameState : IState
    {
        private GameObject _player;
        private IStateSwitcher _stateSwitcher;
        private PlayerMove _playerMove;

        public GameState(GameObject player, IStateSwitcher stateSwitcher, PlayerMove playerMove)
        {
            _player = player;
            _stateSwitcher = stateSwitcher;
            _playerMove = playerMove;
        }

        public async void Enter()
        {
           await _playerMove.Move(_player);

        }

        public void Exit()
        {

        }

    
    }
}