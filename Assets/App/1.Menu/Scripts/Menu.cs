using UnityEngine;

namespace Assets.App.Menu
{
    public class Menu : MonoBehaviour
    {
        [SerializeField]
        private GameObject menuMain;
        [SerializeField]
        private GameObject menuConfiguration;

        void Start()
        {
            ShowMenuMain();
        }

        public void ShowMenuMain()
        {
            menuMain.SetActive(true);
            menuConfiguration.SetActive(false);
        }

        public void ShowMenuConfiguration()
        {
            menuMain.SetActive(false);
            menuConfiguration.SetActive(true);
        }
    }
}
