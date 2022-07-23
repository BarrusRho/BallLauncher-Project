using UnityEngine;
using UnityEngine.InputSystem;

namespace MobileGameDev.BallHandler
{
    public class BallHandler : MonoBehaviour
    {
        private void Update()
        {
            if (!Touchscreen.current.primaryTouch.press.isPressed)
            {
                return;
            }
            else
            {
                Vector2 touchPosition = Touchscreen.current.primaryTouch.position.ReadValue();

                Debug.Log($"{touchPosition}");
            }
        }
    }
}

