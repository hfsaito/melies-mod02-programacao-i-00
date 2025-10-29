using UnityEngine;

namespace Assets.App.Common
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Levitatable : MonoBehaviour
    {
        private Rigidbody2D c_rigidbody2D;

        void Start()
        {
            c_rigidbody2D = GetComponent<Rigidbody2D>();
        }

        public void Levitate()
        {
            c_rigidbody2D.AddForceY(15f);
        }
    }
}
