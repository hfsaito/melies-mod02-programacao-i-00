namespace Assets.App.N1_Menu.Scripts.ConfigMenu
{
    using UnityEngine;
    using UnityEngine.UI;

  [RequireComponent(typeof(Button))]
    public class ButtonBack : MonoBehaviour
    {
        private Button buttonComponent;

        void Start()
        {
            buttonComponent = GetComponent<Button>();
            buttonComponent.onClick.AddListener(HandleClick);
        }

        void HandleClick()
        {
            MenuManager.OpenMenu(MENU.MAIN);
        }
    }
}
