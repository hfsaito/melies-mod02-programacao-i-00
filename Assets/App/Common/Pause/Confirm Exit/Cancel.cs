using UnityEngine;
using UnityEngine.UI;

namespace Assets.App.Common.MenuPause.ConfrimExit
{
    [RequireComponent(typeof(Button))]
    public class Cancel : MonoBehaviour
    {
        [SerializeField]
        private GameObject confirmExitObject;

        private Button c_button;

        void Start()
        {
            c_button = GetComponent<Button>();
            c_button.onClick.AddListener(HandleClick);
        }

        void HandleClick()
        {
            confirmExitObject.SetActive(false);
        }
    }
}
