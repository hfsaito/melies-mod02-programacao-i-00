using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.App.Play.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerMove : MonoBehaviour
    {
        private InputSystem_Actions input;
        private InputAction moveAction;
        private Vector2 moveVector;
        private Rigidbody2D c_rigidbody2d;
        readonly float MOVE_SPEED = 3.5f;

        void Awake()
        {
            input = new();
            moveAction = input.Player.Move;
            c_rigidbody2d = GetComponent<Rigidbody2D>();
        }

        void OnEnable()
        {
            input.Enable();
        }

        void OnDisable()
        {
            input.Disable();
        }

        void FixedUpdate()
        {
            moveVector = moveAction.ReadValue<Vector2>();
            c_rigidbody2d.linearVelocityX = moveVector.x * MOVE_SPEED;
        }
    }
}
