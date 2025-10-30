using UnityEngine;

namespace Assets.App.Play.Player
{
    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(SpriteRenderer))]
    public class PlayerAnimator : MonoBehaviour
    {
        private Animator c_animator;
        private Rigidbody2D c_rigidbody2D;
        private SpriteRenderer c_spriteRenderer;

        void Start()
        {
            c_animator = GetComponent<Animator>();
            c_rigidbody2D = GetComponent<Rigidbody2D>();
            c_spriteRenderer = GetComponent<SpriteRenderer>();
        }

        void Update()
        {
            c_animator.SetBool("Running", c_rigidbody2D.linearVelocityX != 0);
            if (c_rigidbody2D.linearVelocityX > 0) c_spriteRenderer.flipX = false;
            else if (c_rigidbody2D.linearVelocityX < 0) c_spriteRenderer.flipX = true;
        }
    }
}
