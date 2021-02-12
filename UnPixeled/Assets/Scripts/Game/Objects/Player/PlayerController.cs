using Game.Components.GameInput;
using UnityEngine;

namespace Game.Objects.Player
{
    public class PlayerController : MonoBehaviour
    {
        [Header("Editor")]
        [SerializeField] private GameObject playersModel;
        [SerializeField] private GameObject cameraRotator;
        [SerializeField] private Animator animator;

        [Header("Components")]
        [SerializeField] private float moveSpeed;
        
        
        private Transform _playersModelTransform;
        private CharacterController _characterController;
        private MovementInput _movementInput;
        private Vector3 _movementDirection;
        
        
        private static readonly int Idle = Animator.StringToHash("Idle");
        private static readonly int Run = Animator.StringToHash("Run");

        

        private void Awake()
        {
            
            _characterController = GetComponent<CharacterController>();
            _movementInput = gameObject.AddComponent<MovementInput>();
            _playersModelTransform = playersModel.GetComponent<Transform>();
        }

        private void Start()
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        private void Update()
        {
            Move();
            RotatePlayersModel();
        }

        private void Move()
        {
            var movementForward = cameraRotator.transform.forward * (_movementInput.X * Time.deltaTime* moveSpeed);
            var movementRight = cameraRotator.transform.right * (_movementInput.Y* Time.deltaTime* moveSpeed); 
            _movementDirection = movementForward + movementRight;

            _characterController.Move(_movementDirection);
            animator.SetBool(Idle, false);
            animator.SetBool(Run, true);
        }

        private void RotatePlayersModel()
        {
            if (!_movementInput.IsMoving)
            {
                animator.SetBool(Run, false);
                animator.SetBool(Idle, true);
                return;
            }
            _playersModelTransform.transform.rotation = Quaternion.LookRotation(_movementDirection);
        }
    }
}