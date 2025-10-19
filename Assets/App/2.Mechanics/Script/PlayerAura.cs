namespace Assets.App.Mechanics
{
    using UnityEngine;

  [RequireComponent(typeof(SpriteRenderer))]
  public class PlayerAura : MonoBehaviour
    {
        private SpriteRenderer spriteRenderer;
        private RaycastHit2D hit;
        private int auraRaycastLayer;

        void Start()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            auraRaycastLayer = LayerMask.GetMask("Aura Raycast");
        }

        void FixedUpdate()
        {
            hit = Physics2D.CircleCast(
                transform.position, 2, Vector2.zero, 0f, auraRaycastLayer
            );
            if (hit.collider != null)
            {
                // Debug.Log(hit.collider.name);
                hit.rigidbody.AddForceY(15f);
            }

            // Debug.Log()
        }

        void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawWireSphere(transform.position, 2);
        }
    }
}
