using System;
using UnityEngine;
using VContainer.Unity;

namespace Game.Player.Input
{
    public class DesktopInput : Iinput, ITickable
    {
        public event Action<Vector3> ClickDown;
        public event Action<Vector3> ClickUp;
        public event Action<Vector3> Drag;

        private readonly int _leftMouseClick = 0;
        private bool _isSwiping;
        private Vector3 _previousPosition;
        public void Tick()
        {
            ProcessClickUp();
            ProcessClickDown();
            ProcessSwipe();
        }

        private void ProcessClickUp()
        {
            if (UnityEngine.Input.GetMouseButtonUp(_leftMouseClick) == false) return;
            _isSwiping = false;
            ClickUp?.Invoke(UnityEngine.Input.mousePosition);
        }
        
        private void ProcessClickDown()
        {
            if (UnityEngine.Input.GetMouseButtonDown(_leftMouseClick) == false) return;
            _isSwiping = true;
            _previousPosition = UnityEngine.Input.mousePosition;
            ClickDown?.Invoke(_previousPosition);
        }

        private void ProcessSwipe()
        {
            if(_isSwiping == false)
                return;
            if(UnityEngine.Input.mousePosition != _previousPosition)
                Drag?.Invoke(UnityEngine.Input.mousePosition);
            _previousPosition = UnityEngine.Input.mousePosition;
        }
    }
}