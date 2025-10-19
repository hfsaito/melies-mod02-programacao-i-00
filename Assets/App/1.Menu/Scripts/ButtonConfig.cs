namespace Assets.App.N1_Menu.Scripts.MainMenu
{
    using UnityEngine;
    using UnityEngine.UI;

    [RequireComponent(typeof(Button))]
    public class ButtonConfig : MonoBehaviour
    {
        [SerializeField]
        private GameObject menuConfigurationRoot;

        private Button buttonComponent;

        void Start()
        {
            buttonComponent = GetComponent<Button>();
            buttonComponent.onClick.AddListener(HandleClick);
        }

        void HandleClick()
        {
            menuConfigurationRoot.SetActive(true);
        }
    }
}
