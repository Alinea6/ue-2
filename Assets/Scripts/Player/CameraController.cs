using UnityEngine;

namespace Player
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private float _mouseSensitivity = 10.0f;
        private float _rotationY;
        private float _rotationX;

        [SerializeField] private Transform target;
        [SerializeField] private float _distanceFromTarget = 3.0f;

        private Vector3 _currentRotation;
        private Vector3 _smoothVelocity = Vector3.zero;

        [SerializeField] private float _smoothTime = 0.2f;

        [SerializeField] private Vector2 _rotationXMinMax = new Vector2(-180, 180);
        
        void LateUpdate()
        {
            if (target != null)
            {
                float mouseX = Input.GetAxis("Mouse X") * _mouseSensitivity;
                float mouseY = Input.GetAxis("Mouse Y") * _mouseSensitivity;

                _rotationX += mouseX;
                _rotationY += mouseY;

                _rotationX = Mathf.Clamp(_rotationX, _rotationXMinMax.x, _rotationXMinMax.y);
                _rotationY = Mathf.Clamp(_rotationY, _rotationXMinMax.x, _rotationXMinMax.y);
                Vector3 nextRotation = Vector3.up * _rotationX + Vector3.left * _rotationY;

                _currentRotation = Vector3.SmoothDamp(_currentRotation, nextRotation, ref _smoothVelocity, _smoothTime);
                transform.localEulerAngles = _currentRotation;

                transform.position = target.position - transform.forward * _distanceFromTarget;
                transform.position = new Vector3(transform.position.x, transform.position.y + 3.0f, transform.position.z);
            }
        }
    }
}