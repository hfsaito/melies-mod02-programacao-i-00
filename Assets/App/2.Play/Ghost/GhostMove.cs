using UnityEngine;

public class GhostMove : MonoBehaviour
{
    private float initialPosition;
    void Start()
    {
        initialPosition = transform.position.x;
    }
    void FixedUpdate()
    {
        transform.position = new Vector3(
            initialPosition + Mathf.Sin(Time.time),
            transform.position.y
        );
    }
}
