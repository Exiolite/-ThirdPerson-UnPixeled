using UnityEngine;

namespace Game.Components.GameInput
{
    public class MovementInput : MonoBehaviour
    {
        public float X { get; private set; }
        public float Y { get; private set; }
        public bool IsMoving { get; private set; }

        
        private void Update()
        {
            Y = Input.GetAxis("Horizontal");
            X = Input.GetAxis("Vertical");
            if (Y != 0 || X != 0) IsMoving = true;
            else IsMoving = false;
        }
    }
}