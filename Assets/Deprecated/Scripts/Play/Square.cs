using UnityEngine;
using UnityEngine.InputSystem;

public class Square : MonoBehaviour
{
    InputAction moveAction;

    readonly float MOVE_SPEED = 3.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
    }

    // Update is called once per frame
    void Update()
    {
        var direction = moveAction.ReadValue<Vector2>();
        transform.Translate(MOVE_SPEED * Time.deltaTime * direction);
    }
}
