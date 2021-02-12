using Game.Components.GameInput;
using UnityEngine;

namespace Game.Objects.Player
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private Transform rotatorX;
        
        private MouseInput _mouseInput;


        [SerializeField] private float smoothSpeed = 3;
        [SerializeField] private Vector3 offset;
        public Transform target;
        
        
        private void LateUpdate()
        {
            var desiredPosition = target.position + offset;
            var smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
            transform.position = smoothedPosition;
        }
        
        
        private void Awake()
        {
            _mouseInput = gameObject.AddComponent<MouseInput>();
        }

        private void Update()
        {
            RotateCamera();
        }

        private void RotateCamera()
        {
            transform.RotateAround(transform.position, transform.up, _mouseInput.MouseX);
            rotatorX.RotateAround(rotatorX.position, rotatorX.right, _mouseInput.MouseY);
        }
    }
}