using Dreamteck.Splines;
using Game.Data;
using UnityEngine;
using VContainer;

namespace Game.Loot
{
    public class MoneyLoot : MonoBehaviour
    {
        private GameData _gameData;
        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out SplineFollower player)) return;
            _gameData.AddMoney();
            gameObject.SetActive(false);
        }

        [Inject]
        private void Construct(GameData gameData) => _gameData = gameData;
    }
}