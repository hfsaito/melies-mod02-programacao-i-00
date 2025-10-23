using UnityEngine;
using UnityEngine.UI;

namespace Assets.App.Common.MenuPause
{
    [RequireComponent(typeof(Button))]
    public class Exit : MonoBehaviour
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
            confirmExitObject.SetActive(true);
        }
    }
}
