namespace Game.Data
{
    public class GameData
    {
        public PlayerStates CurrentPlayerState { get; private set; }

        public GameData()
        {
            CurrentPlayerState = PlayerStates.Poor;
        }

        public void ChangePlayerState(PlayerStates stateToChange) => CurrentPlayerState = stateToChange;
    }
}