namespace Assets.App.Common.Scripts
{
    using UnityEngine;
    using UnityEngine.UI;

    [RequireComponent(typeof(Image))]
    public class ImageRaycastOnlyOnOpaque : MonoBehaviour
    {
        public Image imageComponent;

        void Start()
        {
            /* FIX:
            *   Click is not registered if click starts
            *   inside an opaque pixel in idle state but
            *   is ignored if that pixel is transparent in
            *   pressed state.
            */
            // imageComponent = GetComponent<Image>();
            // imageComponent.alphaHitTestMinimumThreshold = 1.0f;
        }
    }
}
