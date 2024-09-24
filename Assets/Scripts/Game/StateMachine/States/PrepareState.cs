using Game.Data;
using Game.Player;

namespace Game.StateMachine.States
{
    public class PrepareState : IState
    {
        private PlayerAnimatorController _playerAnimatorController;
        private IStateSwitcher _stateSwitcher;
        private GameData _gameData;

        public PrepareState(PlayerAnimatorController playerAnimatorController, GameData gameData, IStateSwitcher stateSwitcher)
        {
            _playerAnimatorController = playerAnimatorController;
            _gameData = gameData;
            _stateSwitcher = stateSwitcher;
        }

        public void Enter()
        {
            _gameData.ChangePlayerState(PlayerStates.Poor);
            _playerAnimatorController.SetPlayerState(_gameData.CurrentPlayerState);
            _playerAnimatorController.SetIdleState();
            _stateSwitcher.SwitchState<GameState>();
        }

        public void Exit()
        {
           
        }

    }
}