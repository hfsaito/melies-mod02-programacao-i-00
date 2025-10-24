using UnityEngine;
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

        public bool OnGround { get; private set; }
        private bool jumpWasPerformed = false;
        private bool jumpForceWasApplied = false;
        private int groundLayer;
        private RaycastHit2D groundRaycastHit2D;
        private readonly float JUMP_CHECKER_RADIUS = .32f;
        private readonly Vector3 JUMP_CHECKER_OFFSET_POSITION = new(0f, -.32f);
        private readonly float JUMP_FORCE = 4f;

        void Awake()
        {
            input = new();
            moveAction = input.Player.Move;
            jumpAction = input.Player.Jump;

            c_rigidbody2d = GetComponent<Rigidbody2D>();

            groundLayer = LayerMask.GetMask("Ground");
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
            FixedUpdate_Move();
            FixedUpdate_OnGround();
            FixedUpdate_Jump();
        }

        private void FixedUpdate_Move()
        {
            moveVector = moveAction.ReadValue<Vector2>();
            c_rigidbody2d.linearVelocityX = moveVector.x * MOVE_SPEED;
        }

        private void FixedUpdate_OnGround()
        {
            groundRaycastHit2D = Physics2D.CircleCast(
                transform.position + JUMP_CHECKER_OFFSET_POSITION,
                JUMP_CHECKER_RADIUS,
                direction: Vector2.zero,
                distance: 0f,
                groundLayer
            );
            OnGround = groundRaycastHit2D.collider != null;
            if (!OnGround && jumpWasPerformed)
            {
                jumpWasPerformed = false;
                jumpForceWasApplied = false;
            }
        }

        private void FixedUpdate_Jump()
        {
            if (!jumpWasPerformed) return;
            if (jumpForceWasApplied) return;

            jumpForceWasApplied = true;
            c_rigidbody2d.linearVelocityY = 0;
            c_rigidbody2d.AddForceY(JUMP_FORCE, ForceMode2D.Impulse);
        }

        private void HandleJump(InputAction.CallbackContext _context)
        {
            if (!OnGround) return;
            if (jumpWasPerformed) return;

            jumpWasPerformed = true;
        }

        #region EDITOR_ONLY
        void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(
                transform.position + JUMP_CHECKER_OFFSET_POSITION,
                JUMP_CHECKER_RADIUS
            );
        }
        #endregion
    }
}
