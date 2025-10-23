using UnityEngine;
using UnityEngine.UI;

namespace Assets.App.Menu
{
    [RequireComponent(typeof(Button))]
    public class ButtonExit : MonoBehaviour
    {
        private Button c_button;

        void Start()
        {
            c_button = GetComponent<Button>();
            c_button.onClick.AddListener(HandleClick);
        }

        void HandleClick()
        {
            Application.Quit();
        }
    }
}
