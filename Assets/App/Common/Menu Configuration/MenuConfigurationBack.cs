using UnityEngine;
using UnityEngine.UI;

namespace Assets.App.Components.MenuConfiguration
{
    [RequireComponent(typeof(Button))]
    public class MenuConfigurationBack : MonoBehaviour
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
            menuConfigurationRoot.SetActive(false);
        }
    }
}
