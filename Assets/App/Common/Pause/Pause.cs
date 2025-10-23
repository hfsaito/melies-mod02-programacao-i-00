using UnityEngine;
using UnityEngine.InputSystem;

namespace Assets.App.Common.Pause
{
    public class Pause : MonoBehaviour
    {
        [SerializeField]
        private GameObject pauseRoot;
        [SerializeField]
        private GameObject menuPause;
        [SerializeField]
        private GameObject menuConfiguration;

        private InputSystem_Actions input;
        private InputAction pauseAction;

        void Awake()
        {
            input = new();
            pauseAction = input.Player.Pause;
        }

        void OnEnable()
        {
            input.Enable();
            pauseAction.performed += HandlePause;
        }

        void OnDisable()
        {
            input.Disable();
            pauseAction.performed -= HandlePause;
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
            pauseRoot.SetActive(!pauseRoot.activeSelf);
            if (pauseRoot.activeSelf)
            {
                ShowMenuPause();
            }
        }

        private void HandlePause(InputAction.CallbackContext _context)
        {
            Toggle();
        }
    }
}
