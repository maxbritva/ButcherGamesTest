using Game.Data;
using Game.Player;
using UnityEngine;
using Zenject;

namespace Game.StateMachine.States
{
    public class PrepareState : IState
    {
        private PlayerViewChanger _playerViewChanger;
        private GameData _gameData;
        public void Enter()
        {
            _gameData.ChangePlayerState(PlayerStates.Poor);
            _playerViewChanger.SetPlayerView(_gameData.CurrentPlayerState);
        }

        public void Exit()
        {
           
        }

        [Inject] private void Construct(PlayerViewChanger playerViewChanger, GameData gameData)
        {
            _playerViewChanger = playerViewChanger;
            _gameData = gameData;
        }
    }
}