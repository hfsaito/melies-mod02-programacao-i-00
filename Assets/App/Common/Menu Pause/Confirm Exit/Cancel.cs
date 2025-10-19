using UnityEngine;
using UnityEngine.UI;

namespace Assets.App.Common.MenuPause.ConfrimExit
{
    [RequireComponent(typeof(Button))]
    public class Cancel : MonoBehaviour
    {
        [SerializeField]
        private GameObject confirmExitObject;

        private Button buttonComponent;

        void Start()
        {
            buttonComponent = GetComponent<Button>();
            buttonComponent.onClick.AddListener(HandleClick);
        }

        void HandleClick()
        {
            confirmExitObject.SetActive(false);
        }
    }
}
