using GameParameters;
using UnityEngine;

namespace Game.Components.GameInput
{
    public class MouseInput : MonoBehaviour
    {
        public float MouseX { get; private set; }
        public float MouseY { get; private set; }


        
        private void Update()
        {
            MouseX = Input.GetAxis("Mouse X") * (Time.deltaTime * Constants.MouseSensitivity);
            MouseY = -Input.GetAxis("Mouse Y") * (Time.deltaTime * Constants.MouseSensitivity);
        }
    }
}