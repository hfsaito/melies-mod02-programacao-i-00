using UnityEngine;

namespace Assets.App.Play.Player
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerAnimator : MonoBehaviour
    {
        private Animator c_animator;
        private Rigidbody2D c_rigidbody2D;

        void Start()
        {
            c_animator = GetComponent<Animator>();
            c_rigidbody2D = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            c_animator.SetBool("Running", c_rigidbody2D.linearVelocityX != 0);
            if (c_rigidbody2D.linearVelocityX > 0) transform.right = Vector3.right;
            else if (c_rigidbody2D.linearVelocityX < 0) transform.right = Vector3.left;
        }
    }
}
