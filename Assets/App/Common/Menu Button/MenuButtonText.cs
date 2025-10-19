using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Assets.App.Components.MenuButton
{
    [RequireComponent(typeof(Button))]
    [RequireComponent(typeof(HorizontalLayoutGroup))]
    public class MenuButtonText : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        private Button buttonComponent;
        private TextMeshProUGUI textComponent;
        private HorizontalLayoutGroup horizontalLayoutComponent;

        private RectOffset idlePosition;
        private RectOffset pressedPosition;

        private static readonly Color DISABLED_COLOR = new(
            (float)(0x54 / 255.0),
            (float)(0x54 / 255.0),
            (float)(0x54 / 255.0)
        );

        void Start()
        {
            buttonComponent = GetComponent<Button>();
            horizontalLayoutComponent = GetComponent<HorizontalLayoutGroup>();
            textComponent = GetComponentInChildren<TextMeshProUGUI>();

            idlePosition = new(8, 8, 6, 15);
            pressedPosition = new(8, 8, 10, 11);
        }

        void Update()
        {
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
                horizontalLayoutComponent.padding = pressedPosition;
            }
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            horizontalLayoutComponent.padding = idlePosition;
        }
    }

}
