using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.App.Play.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerResetPosition : MonoBehaviour
    {
        private InputSystem_Actions input;
        private InputAction resetPositionAction;
        private Rigidbody2D c_rigidbody2d;
        private Vector2 initialPosition;
        private bool resetPositionRequested = false;

        void Awake()
        {
            input = new();
            resetPositionAction = input.Player.ResetPosition;
            c_rigidbody2d = GetComponent<Rigidbody2D>();
            initialPosition = c_rigidbody2d.position;
        }

        void OnEnable()
        {
            input.Enable();
            resetPositionAction.performed += HandleResetPosition;
        }

        void OnDisable()
        {
            input.Disable();
            resetPositionAction.performed -= HandleResetPosition;
        }

        void FixedUpdate()
        {
            if (resetPositionRequested)
            {
                resetPositionRequested = false;
                c_rigidbody2d.MovePosition(initialPosition);
            }
        }

        private void HandleResetPosition(InputAction.CallbackContext _context)
        {
            resetPositionRequested = true;
        }
    }
}
