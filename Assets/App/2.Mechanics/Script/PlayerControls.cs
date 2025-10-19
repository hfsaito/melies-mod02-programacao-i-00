using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Assets.App.Mechanics
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerControls : MonoBehaviour
    {
        private InputSystem_Actions input;
        private InputAction moveAction;
        private InputAction pauseAction;
        private Vector2 moveVector;
        private Rigidbody2D rb;
        readonly float MOVE_SPEED = 3.5f;

        [SerializeField]
        private UnityEvent onActionPause;

        void Awake()
        {
            input = new();
            moveAction = input.Player.Move;
            pauseAction = input.Player.Pause;

            rb = GetComponent<Rigidbody2D>();
        }

        void OnEnable()
        {
            input.Enable();
            pauseAction.performed += HandlePause;
        }

        void OnDisable()
        {
            input.Disable();
            pauseAction.performed -= HandlePause;
        }

        void FixedUpdate()
        {
            moveVector = moveAction.ReadValue<Vector2>();
            rb.linearVelocityX = moveVector.x * MOVE_SPEED;
        }

        void HandlePause(InputAction.CallbackContext _context)
        {
            onActionPause.Invoke();
        }
    }
}
