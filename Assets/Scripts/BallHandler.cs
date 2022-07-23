using UnityEngine;
using UnityEngine.InputSystem;

namespace MobileGameDev.BallHandler
{
    public class BallHandler : MonoBehaviour
    {
        private Camera _mainCamera;

        private void Start()
        {
            _mainCamera = Camera.main;
        }
        private void Update()
        {
            if (!Touchscreen.current.primaryTouch.press.isPressed)
            {
                return;
            }
            else
            {
                Vector2 touchPosition = Touchscreen.current.primaryTouch.position.ReadValue();

                Vector3 worldPosition = _mainCamera.ScreenToWorldPoint(touchPosition);

                Debug.Log($"{worldPosition}");
            }
        }
    }
}

