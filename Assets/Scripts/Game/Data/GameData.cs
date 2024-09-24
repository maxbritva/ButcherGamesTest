using System;

namespace Game.Data
{
    public class GameData
    {
        public PlayerStates CurrentPlayerState { get; private set; }
        public event Action OnMoneyChanged;
        public int CurrentMoney { get; private set; }

        public GameData()
        {
            CurrentPlayerState = PlayerStates.Poor;
        }

        public void ChangePlayerState(PlayerStates stateToChange) => CurrentPlayerState = stateToChange;

        public void AddMoney()
        {
            CurrentMoney++;
            if (CurrentMoney >= 5)
                CurrentPlayerState = PlayerStates.Rich;
            OnMoneyChanged?.Invoke();
        }
    }
}