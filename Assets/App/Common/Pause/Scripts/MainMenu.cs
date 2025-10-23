using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Assets.App.Common.MenuPause
{
    [RequireComponent(typeof(Button))]
    public class MainMenu : MonoBehaviour
    {
        private Button c_button;

        void Start()
        {
            c_button = GetComponent<Button>();
            c_button.onClick.AddListener(HandleClick);
        }

        void HandleClick()
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
