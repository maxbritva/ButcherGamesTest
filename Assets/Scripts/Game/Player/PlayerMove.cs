using System.Threading;
using Cysharp.Threading.Tasks;
using Game.Level;
using UnityEngine;

namespace Game.Player
{
    public class PlayerMove
    {
        private WaypointsConfig _waypointsConfig;
        private CancellationTokenSource _cts;
        private float _moveSpeed = 3f;
        public PlayerMove(WaypointsConfig waypointsConfig)
        {
            _waypointsConfig = waypointsConfig;
        }
        
        private async UniTask Move(GameObject player)
        {
            _cts = new CancellationTokenSource();
            while (_cts.IsCancellationRequested == false)
            {
                player.transform.position = Vector3.MoveTowards(player.transform.position, _waypointsConfig.WayPoints[0].position, _moveSpeed * Time.deltaTime);
            }
          
        }
    }
}