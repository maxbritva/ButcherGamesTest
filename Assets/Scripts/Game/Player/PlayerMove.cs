using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using Game.Level;
using Game.Player.Input;
using UnityEngine;

namespace Game.Player
{
    public class PlayerMove: IDisposable
    {
        private WaypointsConfig _waypointsConfig;
        private PlayerController _playerController;
        private CancellationTokenSource _cts;
        private float _moveSpeed = 4f;
        private float _moveSpeedVertical = 10f;
        private bool _isPress;
        private Vector3 _directionMove;
        private Vector2 _initialPos;
        private SwipeController _swipeController;
        public PlayerMove(WaypointsConfig waypointsConfig, SwipeController swipeController)
        {
            _swipeController = swipeController;
            _waypointsConfig = waypointsConfig;
            //_playerController = new PlayerController();
        }
        
        

        private void Swipe()
        {
            Debug.Log("press");
            _isPress = true;
            //_initialPos = _playerController.Position;
        }

        public async UniTask Move(GameObject player)
        {
           
            for (int i = 0; i < _waypointsConfig.WayPoints.Count; i++)
            {
                var positionToMove = _waypointsConfig.WayPoints[i].position;
                await RotatePlayer(player, _waypointsConfig.WayPoints[i].rotation).SuppressCancellationThrow();
                
                await MoveToWayPoint(player, positionToMove).SuppressCancellationThrow();
            }
        }
        
        

        private async UniTask MoveToWayPoint(GameObject player, Vector3 positionToMove)
        {
            _cts = new CancellationTokenSource();
            while (true)
            {
                if (_swipeController.swipeLeft)
                    _directionMove = player.transform.localPosition + Vector3.left * _moveSpeedVertical;
                if (_swipeController.swipeRight)
                    _directionMove = Vector3.right;
            
                player.transform.position = Vector3.MoveTowards(player.transform.position, positionToMove + _directionMove.normalized * _moveSpeedVertical, _moveSpeed * Time.deltaTime);
                if ( player.transform.position == positionToMove) _cts.Cancel();

                await UniTask.Yield(PlayerLoopTiming.Update, _cts.Token);
            }
          
        }

        private async UniTask RotatePlayer(GameObject player, Vector3 rotation)
        {
         
            _cts = new CancellationTokenSource();
            while (true)
            {
                player.transform.rotation = Quaternion.Euler(Vector3.Lerp( player.transform.localEulerAngles,  rotation, 15f * Time.deltaTime));
                if (player.transform.rotation == Quaternion.Euler(rotation)) _cts.Cancel();
                await UniTask.Yield(PlayerLoopTiming.Update, _cts.Token);
            }
        }

        public void Dispose()
        {
            _playerController?.Dispose();
        }
    }
}