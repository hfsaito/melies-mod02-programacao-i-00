using UnityEngine;
using UnityEngine.UI;

using Assets.App.Common.Preferences;

namespace Assets.App.Common.MenuConfiguration
{
    [RequireComponent(typeof(Toggle))]
    public class FullScreenToggle : MonoBehaviour
    {
        private Toggle c_toggle;

        void Awake()
        {
            c_toggle = GetComponent<Toggle>();
        }

        void OnEnable()
        {
            c_toggle.isOn = PreferencesState.FullScreen;
            c_toggle.onValueChanged.AddListener(HandleFullscrenToggle);
        }

        void OnDisable()
        {
            c_toggle.onValueChanged.RemoveListener(HandleFullscrenToggle);
        }

        private void HandleFullscrenToggle(bool value)
        {
            PreferencesState.FullScreen = value;
        }
    }
}
