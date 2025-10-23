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
        private Button c_button;
        private TextMeshProUGUI c_text;
        private HorizontalLayoutGroup c_horizontalLayout;

        private RectOffset idlePosition;
        private RectOffset pressedPosition;

        private static readonly Color DISABLED_COLOR = new(
            (float)(0x54 / 255.0),
            (float)(0x54 / 255.0),
            (float)(0x54 / 255.0)
        );

        void Start()
        {
            c_button = GetComponent<Button>();
            c_horizontalLayout = GetComponent<HorizontalLayoutGroup>();
            c_text = GetComponentInChildren<TextMeshProUGUI>();

            idlePosition = new(8, 8, 6, 15);
            pressedPosition = new(8, 8, 10, 11);
        }

        void Update()
        {
            if (c_button.interactable)
            {
                c_text.color = Color.black;
            }
            else
            {
                c_text.color = DISABLED_COLOR;
            }
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            if (c_button.interactable)
            {
                c_horizontalLayout.padding = pressedPosition;
            }
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            c_horizontalLayout.padding = idlePosition;
        }
    }

}
