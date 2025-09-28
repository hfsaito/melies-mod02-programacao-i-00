namespace Assets.App.N1_Menu.Scripts.MainMenu
{
    using UnityEngine;
    using UnityEngine.UI;
    using UnityEngine.SceneManagement;

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
            SceneManager.LoadScene("ScenePlay", LoadSceneMode.Single);
        }
    }
}
