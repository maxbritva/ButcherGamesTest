using UnityEngine;

namespace Game.Player
{
    public static class AnimationsName
    {
        public const string IDLE = "Idle";
        public const string SADWALK = "SadWalk";
        public const string PROUDWALK = "ProudWalk";
        public const string WIN = "Win";
        public const string DEFEAT = "Defeat";
      
    }
    public class AnimationManager : MonoBehaviour
    {
        [SerializeField] private Animator _playerAnimator;

        public void SetIdle() => _playerAnimator.SetTrigger(AnimationsName.IDLE);
        public void SetSadWalk() => _playerAnimator.SetTrigger(AnimationsName.SADWALK);
        public void SetProudWalk() => _playerAnimator.SetTrigger(AnimationsName.PROUDWALK);
    }
}