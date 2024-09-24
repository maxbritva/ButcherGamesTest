using Game.Data;
using UnityEditor.Animations;
using UnityEngine;

namespace Game.Player
{
    public class PlayerAnimatorController : MonoBehaviour
    {
        [Header("Animator")]
        private Animator _animator;
        [SerializeField] private Animator _poor;
        [SerializeField] private Animator _rich;

        [Header("Skins")]
        [SerializeField] private GameObject _poorSkin;
        [SerializeField] private GameObject _richSkin;
        
        
        public void SetPlayerState(PlayerStates playerStates)
        {
            switch (playerStates)
            {
                case PlayerStates.Poor:
                    _animator = _poor;
                    _richSkin.SetActive(false);
                    _poorSkin.SetActive(true);
                    break;
                case PlayerStates.Rich:
                    _poorSkin.SetActive(false);

                    _richSkin.SetActive(true);
                    _animator = _rich;
                    break;
            }
        }
        public void SetIdleState() => _animator.SetTrigger(AnimationsName.IDLE);
        public void SetSadWalkState()
        {
            _animator.SetTrigger(AnimationsName.SADWALK);
        }

        public void SetProudWalkState()
        {
            _animator.SetTrigger(AnimationsName.PROUDWALK);
        }

        public void SetWinState() => _animator.SetTrigger(AnimationsName.WIN);
        public void SetDefeatState() => _animator.SetTrigger(AnimationsName.DEFEAT);
    }
}