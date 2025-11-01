using UnityEngine;
using TMPro;

using Assets.App.Common.Preferences;

namespace Assets.App.Common.MenuConfiguration
{
    [RequireComponent(typeof(TMP_InputField))]
    public class TitleInput : MonoBehaviour
    {
        private TMP_InputField c_input;

        void Awake()
        {
            c_input = GetComponent<TMP_InputField>();
        }

        void OnEnable()
        {
            c_input.text = "";
            c_input.onValueChanged.AddListener(HandleTitleInput);
        }

        void OnDisable()
        {
            c_input.onValueChanged.RemoveListener(HandleTitleInput);
        }

        private void HandleTitleInput(string value)
        {
            // PreferencesState.FullScreen = value;
        }
    }
}
