using Game.Data;
using UnityEngine;

namespace Game.Player
{
    public class PlayerViewChanger : MonoBehaviour
    {
        [Header("Animator")]
        [SerializeField] private Animator _animator;
        [SerializeField] private Avatar _poor;
        [SerializeField] private Avatar _rich;
        [SerializeField] private Avatar _millionaire;

        [Header("Skins")]
        [SerializeField] private GameObject _poorSkin;
        [SerializeField] private GameObject _richSkin;
        [SerializeField] private GameObject _millionaireSkin;
        
        public void SetPlayerView(PlayerStates playerStates)
        {
            _poorSkin.SetActive(false);
            _richSkin.SetActive(false);
            _millionaireSkin.SetActive(false);
            switch (playerStates)
            {
                case PlayerStates.Poor:
                    _animator.avatar = _poor;
                    _poorSkin.SetActive(true);
                    break;
                case PlayerStates.Rich:
                    _animator.avatar = _rich;
                    _richSkin.SetActive(true);
                    break;
                case PlayerStates.Millionaire:
                    _animator.avatar = _millionaire;
                    _millionaireSkin.SetActive(true);
                    break;
                default:
                    _animator.avatar = _animator.avatar;
                    break;
            }
        }
    }
}