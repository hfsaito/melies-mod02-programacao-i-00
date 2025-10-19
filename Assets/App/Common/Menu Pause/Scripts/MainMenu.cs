using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Assets.App.Common.MenuPause
{
    [RequireComponent(typeof(Button))]
    public class MainMenu : MonoBehaviour
    {
        private Button buttonComponent;

        void Start()
        {
            buttonComponent = GetComponent<Button>();
            buttonComponent.onClick.AddListener(HandleClick);
        }

        void HandleClick()
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
