using Game.Data;
using TMPro;
using UnityEngine;
using VContainer;

namespace Game.UI
{
    public class UIMoneyUpdater : MonoBehaviour
    {
        [SerializeField] private TMP_Text _text;
        private GameData _gameData;

        private void OnEnable() => _gameData.OnMoneyChanged += UpdateTextMoney;

        private void OnDestroy() => _gameData.OnMoneyChanged -= UpdateTextMoney;

        private void UpdateTextMoney() => _text.text = _gameData.CurrentMoney.ToString();

        [Inject] private void Construct(GameData gameData) => _gameData = gameData;
    }
}