using System.Threading;
using Cysharp.Threading.Tasks;
using Dreamteck.Splines;
using Game.Data;
using UnityEngine;

namespace Game.Player
{
    public class PlayerMove
    {
        private Transform _player;
        private SplineFollower _splineFollower;
        private float _moveSpeed = 5f;
        private float _moveSpeedHorizontal = 6f;
        private CancellationTokenSource _cts;
        private bool _isMoving;
        private float _lastPositionX;
        private float _deltaPositionX;
        private float _moveRangeX = 2.4f;
        
        public PlayerMove(SplineFollower splineFollower)
        {
            _splineFollower = splineFollower;
            _splineFollower.followSpeed = _moveSpeed;
            _splineFollower.follow = false;
        }

        public async UniTask Move(GameObject player, PlayerAnimatorController playerAnimatorController, GameData gameData)
        {
            _cts = new CancellationTokenSource();
            while (true)
            {
                if (_isMoving == false)
                {
                    if (UnityEngine.Input.GetMouseButtonDown(0))
                    {
                        StartMoving();
                        _isMoving = true;
                        playerAnimatorController.SetSadWalkState();
                        _lastPositionX = UnityEngine.Input.mousePosition.x;
                    }
                }
                else
                {
                    if (UnityEngine.Input.GetMouseButtonDown(0))
                    {
                        _lastPositionX = UnityEngine.Input.mousePosition.x;
                    }

                    if (UnityEngine.Input.GetMouseButton(0))
                    {
                        _deltaPositionX = UnityEngine.Input.mousePosition.x - _lastPositionX;
                        HorizontalMove(player.gameObject.transform);
                        _lastPositionX = UnityEngine.Input.mousePosition.x;
                    }
                    
                    if (UnityEngine.Input.GetMouseButtonUp(0)) _deltaPositionX = 0;
                }

                if (gameData.CurrentPlayerState == PlayerStates.Rich)
                {
                    playerAnimatorController.SetPlayerState(PlayerStates.Rich);
                }
                await UniTask.Yield(PlayerLoopTiming.Update, _cts.Token);
            }
        }
        private void StartMoving() => _splineFollower.follow = true;

        private void HorizontalMove(Transform player)
        {
            var localPosition = player.localPosition;
            var horizontalMove = localPosition.x + _deltaPositionX ;
            horizontalMove = Mathf.Clamp(horizontalMove, -_moveRangeX, _moveRangeX);
            var newPosition = new Vector3(horizontalMove, localPosition.y, localPosition.z);
            player.transform.localPosition = Vector3.Lerp(player.transform.localPosition, newPosition,
                _moveSpeedHorizontal * Time.deltaTime);
        }
    }
}