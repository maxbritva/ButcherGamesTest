using UnityEngine;

namespace Game.Player
{
    public static class AnimationsName
    {
        public const string IDLE = "Idle";
    }
    public class AnimationManager : MonoBehaviour
    {
        [SerializeField] private Animator _playerAnimator;

        public void SetIdle() => _playerAnimator.SetTrigger(AnimationsName.IDLE);
    }
}