using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Assets.App.Play.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMovement : MonoBehaviour
    {
        private InputSystem_Actions input;
        private InputAction moveAction;
        private InputAction jumpAction;
        private Vector2 moveVector;
        private Rigidbody2D c_rigidbody2d;
        readonly float MOVE_SPEED = 3.5f;

        void Awake()
        {
            input = new();
            moveAction = input.Player.Move;
            jumpAction = input.Player.Jump;

            c_rigidbody2d = GetComponent<Rigidbody2D>();
        }

        void OnEnable()
        {
            input.Enable();
            jumpAction.performed += HandleJump;
        }

        void OnDisable()
        {
            input.Disable();
            jumpAction.performed -= HandleJump;
        }

        void FixedUpdate()
        {
            moveVector = moveAction.ReadValue<Vector2>();
            c_rigidbody2d.linearVelocityX = moveVector.x * MOVE_SPEED;
        }

        void HandleJump(InputAction.CallbackContext _context)
        {

        }
    }
}
