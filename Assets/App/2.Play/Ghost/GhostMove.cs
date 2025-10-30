using UnityEngine;

namespace Assets.App.Play.Ghost
{
    public class GhostMove : MonoBehaviour
    {
        private float initialPosition;
        void Start()
        {
            initialPosition = transform.position.x;
        }
        void Update()
        {
            transform.position = new Vector3(
                initialPosition + Mathf.Sin(Time.time),
                transform.position.y
            );
        }
    }
}
