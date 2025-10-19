using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace Assets.App.Menu
{
    [RequireComponent(typeof(Button))]
    public class ButtonPlay : MonoBehaviour
    {
        private Button buttonComponent;

        void Start()
        {
            buttonComponent = GetComponent<Button>();
            buttonComponent.onClick.AddListener(HandleClick);
        }

        void HandleClick()
        {
            SceneManager.LoadScene("Mechanics");
        }
    }
}
