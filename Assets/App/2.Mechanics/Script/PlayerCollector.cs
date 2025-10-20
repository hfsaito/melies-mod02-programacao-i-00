using UnityEngine;

namespace Assets.App.Mechanics
{
    public class PlayerCollector : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Collectable"))
            {
                Destroy(other.gameObject);
            }
        }
    }
}
