using System;
using UnityEngine;

namespace Game.Player.Input
{
    public interface Iinput
    {
        event Action<Vector3> ClickDown;
        event Action<Vector3> ClickUp;
        event Action<Vector3> Drag;
    }
}