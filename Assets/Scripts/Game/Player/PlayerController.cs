using System;
using Game.Player.Input;
using UnityEngine;

namespace Game.Player
{
    public class PlayerController: IDisposable
    {
        private Iinput _input;
        
        public PlayerController()
        {
            _input = new DesktopInput();
            _input.ClickUp += OnClickUp;
            _input.ClickDown += OnClickDown;
            _input.Drag += OnDrag;
        }

        private void OnClickDown(Vector3 position)
        {
            
        }
        
        private void OnClickUp(Vector3 position)
        {
            
        }
        
        private void OnDrag(Vector3 position)
        {
            
        }

        public void Dispose()
        {
            _input.ClickUp -= OnClickUp;
            _input.ClickDown -= OnClickDown;
            _input.Drag -= OnDrag;
        }
    }
}