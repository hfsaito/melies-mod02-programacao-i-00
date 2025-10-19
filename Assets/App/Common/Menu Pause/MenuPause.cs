using UnityEngine;

namespace Assets.App.Common.MenuPause
{
    public class MenuPause : MonoBehaviour
    {
        [SerializeField]
        private GameObject menuPause;
        [SerializeField]
        private GameObject menuConfiguration;

        void OnEnable()
        {
            Time.timeScale = 0;
        }

        void OnDisable()
        {
            Time.timeScale = 1;
        }

        void Start()
        {
            gameObject.SetActive(false);
        }

        public void ShowMenuPause()
        {
            menuPause.SetActive(true);
            menuConfiguration.SetActive(false);
        }

        public void ShowMenuConfiguration()
        {
            menuPause.SetActive(false);
            menuConfiguration.SetActive(true);
        }

        public void Toggle()
        {
            gameObject.SetActive(!gameObject.activeSelf);
            if (gameObject.activeSelf)
            {
                ShowMenuPause();
            }
        }
    }
}
