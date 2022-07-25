using UnityEngine;
using UnityEngine.InputSystem;

namespace MobileGameDev.BallHandler
{
    public class BallHandler : MonoBehaviour
    {
        [SerializeField]
        private Rigidbody2D _ballRigidbody;

        [SerializeField]
        private SpringJoint2D _ballSpringJoint;

        [SerializeField]
        private float _detachDelay;
        private Camera _mainCamera;
        private bool _isDragging;


        private void Start()
        {
            _mainCamera = Camera.main;
        }

        private void Update()
        {
            if (_ballRigidbody == null)
            {
                return;
            }

            if (!Touchscreen.current.primaryTouch.press.isPressed)
            {
                if (_isDragging == true)
                {
                    LaunchBall();
                }

                _isDragging = false;

                return;
            }
            else
            {
                _isDragging = true;

                _ballRigidbody.isKinematic = true;

                Vector2 touchPosition = Touchscreen.current.primaryTouch.position.ReadValue();

                Vector3 worldPosition = _mainCamera.ScreenToWorldPoint(touchPosition);

                _ballRigidbody.position = worldPosition;

                Debug.Log($"{worldPosition}");
            }
        }

        private void LaunchBall()
        {
            _ballRigidbody.isKinematic = false;
            _ballRigidbody = null;

            Invoke(nameof(DetachBall), _detachDelay);
        }

        private void DetachBall()
        {
            _ballSpringJoint.enabled = false;
            _ballSpringJoint = null;
        }
    }
}

