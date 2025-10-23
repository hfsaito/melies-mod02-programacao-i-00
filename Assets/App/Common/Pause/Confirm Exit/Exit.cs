using UnityEngine;
using UnityEngine.UI;

namespace Assets.App.Common.MenuPause.ConfrimExit
{
    [RequireComponent(typeof(Button))]
    public class Exit : MonoBehaviour
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
