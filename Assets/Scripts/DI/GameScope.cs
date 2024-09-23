using Game;
using Game.Data;
using Game.Level;
using Game.Player;
using Game.StateMachine;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace DI
{
    public class GameScope : LifetimeScope
    {
        [SerializeField] private PlayerViewChanger _playerViewChanger;
        [SerializeField] private WaypointsConfig _waypointsConfig;
        [SerializeField] private SwipeController _swipeController;
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<GameEntryPoint>();
            builder.Register<GameData>(Lifetime.Singleton);
            builder.Register<PlayerMove>(Lifetime.Singleton);
            builder.RegisterInstance(_waypointsConfig);
            builder.RegisterInstance(_playerViewChanger);
            builder.RegisterInstance(_swipeController);
            builder.Register<GameStateMachine>(Lifetime.Singleton);
        }
    }
}