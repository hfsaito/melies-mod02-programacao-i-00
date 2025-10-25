using UnityEngine;
using UnityEngine.Events;

namespace Assets.App.Common.Coin
{
    public class Coin : MonoBehaviour
    {
        public readonly UnityEvent OnDestroyEvent = new();

        void OnDestroy()
        {
            OnDestroyEvent.Invoke();
        }
    }
}
