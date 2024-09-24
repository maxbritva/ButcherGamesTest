using Dreamteck.Splines;
using Game;
using Game.Data;
using Game.Level;
using Game.Player;
using Game.StateMachine;
using UnityEngine;
using UnityEngine.Serialization;
using VContainer;
using VContainer.Unity;

namespace DI
{
    public class GameScope : LifetimeScope
    {
       [SerializeField] private PlayerAnimatorController playerAnimatorController;
        [SerializeField] private WaypointsConfig _waypointsConfig;
        [SerializeField] private SplineComputer _splineComputer;
        [SerializeField] private SplineFollower _splineFollower;
        protected override void Configure(IContainerBuilder builder)
        {
            builder.RegisterEntryPoint<GameEntryPoint>();
            builder.Register<GameData>(Lifetime.Singleton);
            builder.Register<PlayerMove>(Lifetime.Singleton);
            builder.RegisterInstance(_waypointsConfig);
            builder.RegisterInstance(playerAnimatorController);
            builder.RegisterInstance(_splineComputer);
            builder.RegisterInstance(_splineFollower);
            builder.Register<GameStateMachine>(Lifetime.Singleton);
        }
    }
}