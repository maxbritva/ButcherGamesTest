using UnityEngine;

namespace Game.Player
{
    public class SwipeController : MonoBehaviour
    {
        public bool tap, swipeLeft, swipeRight, swipeUp, swipeDown;
        private bool isDraging;
        private Vector2 startTouch, swipeDelta;

        private void Update()
        {
            tap = swipeDown = swipeUp = swipeLeft = swipeRight = false;
         
            if (UnityEngine.Input.GetMouseButtonDown(0))
            {
                tap = true;
                isDraging = true;
                startTouch = UnityEngine.Input.mousePosition;
            }
            else if (UnityEngine.Input.GetMouseButtonUp(0))
            {
                isDraging = false;
                Reset();
            }

            swipeDelta = Vector2.zero;
            if (isDraging)
            {
                if (UnityEngine.Input.touches.Length < 0)
                    swipeDelta = UnityEngine.Input.touches[0].position - startTouch;
                else if (UnityEngine.Input.GetMouseButton(0))
                    swipeDelta = (Vector2)UnityEngine.Input.mousePosition - startTouch;
            }

          
            if (swipeDelta.magnitude > 100)
            {
                float x = swipeDelta.x;
                float y = swipeDelta.y;
                if (Mathf.Abs(x) > Mathf.Abs(y))
                {
                    
                    if (x < 0)
                        swipeLeft = true;
                    else
                        swipeRight = true;
                }
                else
                {
                    
                    if (y < 0)
                        swipeDown = true;
                    else
                        swipeUp = true;
                }

                Reset();
            }

        }

        private void Reset()
        {
            startTouch = swipeDelta = Vector2.zero;
            isDraging = false;
        }
}
    }
