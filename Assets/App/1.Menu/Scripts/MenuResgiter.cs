namespace Assets.App.N1_Menu.Scripts
{
    using UnityEngine;

    public class ButtonBack : MonoBehaviour
    {
        [SerializeField]
        private MENU menuId;

        [SerializeField]
        private bool defaultActive;

        void Start()
        {
            MenuManager.RegisterMenu(menuId, gameObject, defaultActive);
        }
    }
}
