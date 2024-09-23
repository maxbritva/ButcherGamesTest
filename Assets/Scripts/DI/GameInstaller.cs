using Game.Data;
using Game.Player;
using Game.StateMachine;
using UnityEngine;
using Zenject;

namespace DI
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private PlayerViewChanger _playerViewChanger;
        public override void InstallBindings()
        {
            Container.Bind<GameData>().FromNew().AsSingle().NonLazy();
            Container.Bind<PlayerViewChanger>().FromInstance(_playerViewChanger).AsSingle().NonLazy();
            Container.Bind<GameStateMachine>().FromNew().AsSingle().NonLazy();
           
        }
    }
}