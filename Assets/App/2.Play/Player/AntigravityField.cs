using UnityEngine;

using Assets.App.Common;

namespace Assets.App.Play.Player
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class AntigravityField : MonoBehaviour
    {
        private RaycastHit2D hit;
        private int antigravityLayer;

        void Start()
        {
            antigravityLayer = LayerMask.GetMask("Levitatables");
        }

        void FixedUpdate()
        {
            hit = Physics2D.CircleCast(
                transform.position, 2, Vector2.zero, 0f, antigravityLayer
            );
            if (hit.collider != null)
            {
                hit.rigidbody.AddForceY(15f);
            }
        }
    }
}
