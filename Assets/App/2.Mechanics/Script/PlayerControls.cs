namespace Assets.App.Mechanics
{
    using UnityEngine;
    using UnityEngine.InputSystem;

    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerControls : MonoBehaviour
    {
        private InputAction moveAction;
        private Vector2 moveVector;
        private Rigidbody2D rb;
        readonly float MOVE_SPEED = 3.5f;

        void Start()
        {
            moveAction = InputSystem.actions.FindAction("Move");
            rb = GetComponent<Rigidbody2D>();
        }

        void FixedUpdate()
        {
            moveVector = moveAction.ReadValue<Vector2>();
            rb.linearVelocityX = moveVector.x * MOVE_SPEED;
        }
    }
}
