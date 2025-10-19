using UnityEngine;
using UnityEngine.UI;

namespace Assets.App.Menu
{
    [RequireComponent(typeof(Button))]
    public class ButtonExit : MonoBehaviour
    {
        private Button buttonComponent;

        void Start()
        {
            buttonComponent = GetComponent<Button>();
            buttonComponent.onClick.AddListener(HandleClick);
        }

        void HandleClick()
        {
            Application.Quit();
        }
    }
}
