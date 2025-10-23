using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Audio;

namespace Assets.App.Common.Preferences
{
    public class PreferencesState
    {
        public static bool AlreadyLoaded { get; private set; }
        public static void Load(AudioMixer audioMixer)
        {
            if (AlreadyLoaded) return;
            AlreadyLoaded = true;
            LoadFullScreen();
            LoadVolume(audioMixer);
            LoadResolution();
        }

        #region FULLSCREEN
        public static bool FullScreen
        {
            get { return fullScreen; }
            set { SaveFullScreen(value); }
        }
        private static bool fullScreen;
        private const string FULLSCREEN = "FULLSCREEN";
        private const int DEFAULT_FULLSCREEN = 1;
        private static void LoadFullScreen()
        {
            ApplyFullScreen(
                PlayerPrefs.GetInt(FULLSCREEN, DEFAULT_FULLSCREEN) == 1
            );
        }
        private static void SaveFullScreen(bool value)
        {
            ApplyFullScreen(value);
            PlayerPrefs.SetInt(FULLSCREEN, fullScreen ? 1 : 0);
        }
        private static void ApplyFullScreen(bool value)
        {
            fullScreen = value;
            Screen.fullScreen = value;
        }
        #endregion

        #region VOLUME
        public static float Volume
        {
            get { return volume; }
            set { SaveVolume(value); }
        }
        private static float volume;
        private static AudioMixer c_audioMixer;
        private const string VOLUME = "VOLUME";
        private const float DEFAULT_VOLUME = .75f;
        private static void LoadVolume(AudioMixer audioMixer)
        {
            c_audioMixer = audioMixer;
            ApplyVolume(PlayerPrefs.GetFloat(VOLUME, DEFAULT_VOLUME));
        }
        private static void SaveVolume(float value)
        {
            ApplyVolume(value);
            PlayerPrefs.SetFloat(VOLUME, volume);
        }
        private static void ApplyVolume(float value)
        {
            volume = value;
            c_audioMixer.SetFloat("Master", Mathf.Log10(volume) * 20);
        }
        #endregion

        #region RESOLUTION
        public static int ResolutionIndex
        {
            get { return resolutionIndex; }
            set { SaveResolutionIndex(value); }
        }
        public static Resolution[] ResolutionOpions { get; private set; }
        private static int resolutionIndex;
        private const string RESOLUTION_INDEX = "RESOLUTION_INDEX";
        private static void LoadResolution()
        {
            ResolutionOpions = Screen.resolutions;
            ApplyResolutionIndex(PlayerPrefs.GetInt(RESOLUTION_INDEX, ResolutionOpions.Count() - 1));
        }
        private static void SaveResolutionIndex(int value)
        {
            ApplyResolutionIndex(value);
            PlayerPrefs.SetInt(RESOLUTION_INDEX, resolutionIndex);
        }
        private static void ApplyResolutionIndex(int value)
        {
            resolutionIndex = Math.Clamp(value, 0, ResolutionOpions.Count() - 1);
            Screen.SetResolution(
                ResolutionOpions[resolutionIndex].width,
                ResolutionOpions[resolutionIndex].height,
                Screen.fullScreenMode,
                ResolutionOpions[resolutionIndex].refreshRateRatio
            );
        }
        #endregion
    }
}
