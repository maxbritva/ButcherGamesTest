using Game.Data;
using Game.Player;

namespace Game.StateMachine.States
{
    public class PrepareState : IState
    {
        private PlayerViewChanger _playerViewChanger;
        private IStateSwitcher _stateSwitcher;
        private GameData _gameData;

        public PrepareState(PlayerViewChanger playerViewChanger, GameData gameData, IStateSwitcher stateSwitcher)
        {
            _playerViewChanger = playerViewChanger;
            _gameData = gameData;
            _stateSwitcher = stateSwitcher;
        }

        public void Enter()
        {
            _gameData.ChangePlayerState(PlayerStates.Poor);
            _playerViewChanger.SetPlayerView(_gameData.CurrentPlayerState);
            _stateSwitcher.SwitchState<GameState>();
        }

        public void Exit()
        {
           
        }

    }
}