using UnityEngine;
using UnityEngine.InputSystem;

namespace MobileGameDev.BallHandler
{
    public class BallHandler : MonoBehaviour
    {
        private Camera _mainCamera;

        [SerializeField]
        private Rigidbody2D _ballRigidbody;

        private void Start()
        {
            _mainCamera = Camera.main;
        }
        private void Update()
        {
            if (!Touchscreen.current.primaryTouch.press.isPressed)
            {
                _ballRigidbody.isKinematic = false;

                return;
            }
            else
            {
                _ballRigidbody.isKinematic = true;

                Vector2 touchPosition = Touchscreen.current.primaryTouch.position.ReadValue();

                Vector3 worldPosition = _mainCamera.ScreenToWorldPoint(touchPosition);

                _ballRigidbody.position = worldPosition;

                Debug.Log($"{worldPosition}");
            }
        }
    }
}

