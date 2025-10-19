using UnityEngine;
using UnityEngine.UI;

namespace Assets.App.Common.MenuPause
{
    [RequireComponent(typeof(Button))]
    public class Exit : MonoBehaviour
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
            confirmExitObject.SetActive(true);
        }
    }
}
