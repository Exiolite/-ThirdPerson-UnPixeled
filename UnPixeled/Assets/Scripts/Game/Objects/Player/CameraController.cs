using Game.Components.GameInput;
using UnityEngine;

namespace Game.Objects.Player
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private Transform rotatorX;
        
        private MouseInput _mouseInput;


        
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