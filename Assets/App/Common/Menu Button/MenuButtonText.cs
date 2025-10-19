using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Assets.App.Components.MenuButton
{
    [RequireComponent(typeof(Button))]
    public class MenuButtonText : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        private Button buttonComponent;
        private GameObject textGameObject;
        private TextMeshProUGUI textComponent;

        private Vector3 unpressedPosition;
        private Vector3 pressedPosition;

        private static readonly Vector3 PRESSED_OFFSET = new(0, -4, 0);
        private static readonly Color DISABLED_COLOR = new(
            (float)(0x54 / 255.0),
            (float)(0x54 / 255.0),
            (float)(0x54 / 255.0)
        );

        void Start()
        {
            buttonComponent = GetComponent<Button>();
            textComponent = GetComponentInChildren<TextMeshProUGUI>();
            textGameObject = textComponent.gameObject;
            unpressedPosition = textGameObject.transform.localPosition;
            pressedPosition = unpressedPosition + PRESSED_OFFSET;
        }

        void Update()
        {
            if (textComponent == null)
            {
                Debug.LogWarning("missing text component");
                return;
            }
            if (buttonComponent.interactable)
            {
                textComponent.color = Color.black;
            }
            else
            {
                textComponent.color = DISABLED_COLOR;
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (buttonComponent.interactable)
            {
                textGameObject.transform.localPosition = pressedPosition;
            }
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            textGameObject.transform.localPosition = unpressedPosition;
        }
    }

}
