using Game.Data;
using Game.Player;
using UnityEngine;

namespace Game.StateMachine.States
{
    public class GameState : IState
    {
        private GameObject _player;
        private IStateSwitcher _stateSwitcher;
        private PlayerMove _playerMove;
        private PlayerAnimatorController _playerAnimatorController;
        private GameData _gameData;

        public GameState(GameObject player, IStateSwitcher stateSwitcher, PlayerMove playerMove, PlayerAnimatorController playerAnimatorController, GameData gameData)
        {
            _player = player;
            _gameData = gameData;
            _stateSwitcher = stateSwitcher;
            _playerMove = playerMove;
            _playerAnimatorController = playerAnimatorController;
        }

        public async void Enter()
        {
            await _playerMove.Move(_player, _playerAnimatorController, _gameData);
        }

        public void Exit()
        {

        }

    
    }
}