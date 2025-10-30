using System.Collections;

using UnityEngine;
using UnityEngine.Events;

namespace Assets.App.Common.Coin
{
    [RequireComponent(typeof(SpriteRenderer))]
    [RequireComponent(typeof(Collider2D))]
    public class Coin : Collectable
    {
        public readonly UnityEvent OnCollectEvent = new();

        [SerializeField] private ParticleSystem particlesOnDestroy;
        private SpriteRenderer c_spriteRenderer;
        private Collider2D c_collider2d;
        private static readonly WaitForSeconds destructionDelay = new(1f);

        void Awake()
        {
            c_spriteRenderer = GetComponent<SpriteRenderer>();
            c_collider2d = GetComponent<Collider2D>();
        }

        public override void Collect()
        {
            c_spriteRenderer.enabled = false;
            c_collider2d.enabled = false;
            particlesOnDestroy.Emit(5);
            OnCollectEvent.Invoke();
            StartCoroutine(DestroyAfterBeenCollected());
        }

        private IEnumerator DestroyAfterBeenCollected()
        {
            yield return destructionDelay;
            Destroy(gameObject);
        }
    }
}
