using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Assets.App.Menu
{
    [RequireComponent(typeof(Button))]
    public class ButtonPlay : MonoBehaviour
    {
        private Button c_button;

        void Start()
        {
            c_button = GetComponent<Button>();
            c_button.onClick.AddListener(HandleClick);
        }

        void HandleClick()
        {
            SceneManager.LoadScene("Play");
        }
    }
}
