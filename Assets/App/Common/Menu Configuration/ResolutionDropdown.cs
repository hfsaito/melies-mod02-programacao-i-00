using UnityEngine;
using TMPro;

using Assets.App.Common.Preferences;
using System.Linq;

namespace Assets.App.Common.MenuConfiguration
{
    [RequireComponent(typeof(TMP_Dropdown))]
    public class ResolutionDropdown : MonoBehaviour
    {
        private TMP_Dropdown c_dropdown;

        void Awake()
        {
            c_dropdown = GetComponent<TMP_Dropdown>();
        }

        void OnEnable()
        {
            if (c_dropdown.options.Count() > 0)
            {
                c_dropdown.value = PreferencesState.ResolutionIndex;
            }
            c_dropdown.onValueChanged.AddListener(HandleResolutionChange);
        }

        void OnDisable()
        {
            c_dropdown.onValueChanged.RemoveListener(HandleResolutionChange);
        }

        void Start()
        {
            c_dropdown.ClearOptions();
            c_dropdown.AddOptions(
                PreferencesState.ResolutionOpions
                    .Select(res => $"{res.width} x {res.height} @ {res.refreshRateRatio:F2}Hz")
                    .ToList()
            );
            c_dropdown.value = PreferencesState.ResolutionIndex;
        }

        private void HandleResolutionChange(int index)
        {
            PreferencesState.ResolutionIndex = index;
        }
    }
}
