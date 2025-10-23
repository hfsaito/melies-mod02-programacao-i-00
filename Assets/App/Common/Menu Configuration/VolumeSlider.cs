using UnityEngine;
using UnityEngine.UI;

using Assets.App.Common.Preferences;

namespace Assets.App.Common.MenuConfiguration
{
    [RequireComponent(typeof(Slider))]
    public class VolumeSlider : MonoBehaviour
    {
        private Slider c_slider;

        void Awake()
        {
            c_slider = GetComponent<Slider>();
        }

        void OnEnable()
        {
            c_slider.value = PreferencesState.Volume;
            c_slider.onValueChanged.AddListener(HandleVolumeChange);
        }

        void OnDisable()
        {
            c_slider.onValueChanged.RemoveListener(HandleVolumeChange);
        }

        private void HandleVolumeChange(float value)
        {
            PreferencesState.Volume = value;
        }
    }
}
