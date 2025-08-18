using UnityEngine;
using UnityEngine.UI;

public class ButtonIgnoreTransparentClick : MonoBehaviour
{
    public Image imageComponent;

    void Start()
    {
        imageComponent = GetComponent<Image>();
        imageComponent.alphaHitTestMinimumThreshold = 0.5f;
    }
}
