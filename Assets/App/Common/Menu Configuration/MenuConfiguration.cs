using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace Assets.App.Components.MenuConfiguration
{
    public class MenuConfiguration : MonoBehaviour
    {
        [SerializeField]
        private Toggle fullscreenToggle;

        [SerializeField]
        private Slider volumeSlider;
        [SerializeField]
        private AudioMixer audioMixer;

        [SerializeField]
        private TMP_Dropdown resolutionDropdown;
        private Resolution[] resolutions;
        private List<string> resolutionOptions;

        void OnEnable()
        {
            fullscreenToggle.onValueChanged.AddListener(HandleFullscrenToggle);
            volumeSlider.onValueChanged.AddListener(HandleVolumeChange);
            resolutionDropdown.onValueChanged.AddListener(HandleResolutionChange);
        }

        void OnDisable()
        {
            fullscreenToggle.onValueChanged.RemoveListener(HandleFullscrenToggle);
            volumeSlider.onValueChanged.AddListener(HandleVolumeChange);
        }

        void Start()
        {
            gameObject.SetActive(false);

            resolutions = EligibleResolutions();
            resolutionOptions = resolutions
                .Select(res => $"{res.width} x {res.height} @ {res.refreshRateRatio:F2}Hz")
                .ToList();
            resolutionDropdown.ClearOptions();
            resolutionDropdown.AddOptions(resolutionOptions);
        }

        private void HandleFullscrenToggle(bool value)
        {
            Screen.fullScreen = value;
        }

        private void HandleVolumeChange(float value)
        {
            audioMixer.SetFloat("Master", Mathf.Log10(value) * 20);
        }

        private void HandleResolutionChange(int index)
        {
            Screen.SetResolution(
                resolutions[index].width,
                resolutions[index].height,
                Screen.fullScreenMode,
                resolutions[index].refreshRateRatio
            );
        }

        private readonly ReadOnlyDictionary<string, bool> ELIGIBLE_RATIOS = new(new Dictionary<string, bool>(){
            [$"{16f / 9f:F2}"] = true,
            [$"{5f / 4f:F2}"] = true,
            [$"{4f / 3f:F2}"] = true,
            [$"{21f / 9f:F2}"] = true,
        });
        private Resolution[] EligibleResolutions()
        {
            var refreshRatesAvailabel = Screen.resolutions
                .Select(res => res.refreshRateRatio.value)
                .Aggregate(new Dictionary<double, bool>(), (result, refreshRate) =>
                {
                    result.TryAdd(refreshRate, true);
                    return result;
                });
            return Screen.resolutions
                .Where(res => {
                    var foo = ELIGIBLE_RATIOS.GetValueOrDefault($"{res.width / (float)res.height:F2}", false);
                    if (!foo) return false;

                    var roundedRefreshRAte = Math.Round(res.refreshRateRatio.value);
                    if (roundedRefreshRAte == res.refreshRateRatio.value) return true;
                    return !refreshRatesAvailabel.GetValueOrDefault(roundedRefreshRAte, false);
                })
                .ToArray();
        }
    }
}
