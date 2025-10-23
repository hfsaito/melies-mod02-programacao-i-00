using UnityEngine;

namespace Assets.App.Play.Player
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
