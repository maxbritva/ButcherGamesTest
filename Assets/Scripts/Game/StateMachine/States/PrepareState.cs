using Game.Data;
using Game.Player;

namespace Game.StateMachine.States
{
    public class PrepareState : IState
    {
        private PlayerViewChanger _playerViewChanger;
        private GameData _gameData;

        public PrepareState(PlayerViewChanger playerViewChanger, GameData gameData)
        {
            _playerViewChanger = playerViewChanger;
            _gameData = gameData;
        }

        public void Enter()
        {
            _gameData.ChangePlayerState(PlayerStates.Poor);
            _playerViewChanger.SetPlayerView(_gameData.CurrentPlayerState);
        }

        public void Exit()
        {
           
        }

    }
}