using UnityEngine;

namespace Assets.App.Common
{
    public class Collectable : MonoBehaviour
    {
        public void Collect()
        {
            Destroy(gameObject);
        }
    }
}
