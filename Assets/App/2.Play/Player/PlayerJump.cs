using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.App.Play.Player
{
    public enum PLAYER_JUMP_STATE
    {
        IDLE,
        JUMP_REQUESTED,
        JUMP_APPLIED
    }

    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerJump : MonoBehaviour
    {
        private InputSystem_Actions input;
        private InputAction jumpAction;
        private Rigidbody2D c_rigidbody2d;

        private PLAYER_JUMP_STATE jump_state;
        private int groundLayer;
        private RaycastHit2D groundRaycastHit2D;
        private readonly float JUMP_CHECKER_RADIUS = .32f;
        private readonly Vector3 JUMP_CHECKER_OFFSET_POSITION = new(0f, -.32f);
        private readonly float JUMP_FORCE = 6f;

        void Awake()
        {
            input = new();
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
            if (jump_state == PLAYER_JUMP_STATE.IDLE)
            {
                return;
            }

            if (jump_state == PLAYER_JUMP_STATE.JUMP_REQUESTED)
            {
                c_rigidbody2d.linearVelocityY = 0;
                c_rigidbody2d.AddForceY(JUMP_FORCE, ForceMode2D.Impulse);
                jump_state = PLAYER_JUMP_STATE.JUMP_APPLIED;
            }

            if (!OnGround())
            {
                jump_state = PLAYER_JUMP_STATE.IDLE;
            }
        }

        private void HandleJump(InputAction.CallbackContext _context)
        {
            if (OnGround() && jump_state == PLAYER_JUMP_STATE.IDLE)
            {
                jump_state = PLAYER_JUMP_STATE.JUMP_REQUESTED;
            }
        }

        private bool OnGround()
        {
            groundRaycastHit2D = Physics2D.CircleCast(
                transform.position + JUMP_CHECKER_OFFSET_POSITION,
                JUMP_CHECKER_RADIUS,
                direction: Vector2.zero,
                distance: 0f,
                groundLayer
            );
            return groundRaycastHit2D.collider != null;
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
