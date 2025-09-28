namespace Assets.App.Common.Scripts
{
    using TMPro;
    using UnityEngine;
    using UnityEngine.UI;
    using UnityEngine.EventSystems;

    [RequireComponent(typeof(Button))]
    public class ButtonText : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        private Button buttonComponent;
        [SerializeField]
        private GameObject textGameObject;
        private TextMeshProUGUI textComponent;
        private bool pressed;

        private Vector3 unpressedPosition;
        private Vector3 pressedPosition;

        private static readonly Vector3 PRESSED_OFFSET = new(0, -4 ,0);

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            buttonComponent = GetComponent<Button>();
            textComponent = textGameObject.GetComponent<TextMeshProUGUI>();
            unpressedPosition = textGameObject.transform.localPosition;
            pressedPosition = unpressedPosition + PRESSED_OFFSET;
        }

        // Update is called once per frame
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
                textComponent.color = new Color(
                    (float)(0x54 / 255.0),
                    (float)(0x54 / 255.0),
                    (float)(0x54 / 255.0)
                );

            }
            if (pressed)
            {
                textGameObject.transform.localPosition = pressedPosition;
            }
            else
            {
                textGameObject.transform.localPosition = unpressedPosition;
            }
        }

        
        public void OnPointerDown(PointerEventData eventData)
        {
            pressed = true;
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            pressed = false;
        }
    }

}
