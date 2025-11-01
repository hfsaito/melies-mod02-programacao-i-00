using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Audio;

namespace Assets.App.Common.Preferences
{
    public class PreferencesState
    {
        private struct PLAYER_PREF_KEYS
        {
            public const string FULLSCREEN = "FULLSCREEN";
            public const string VOLUME = "VOLUME";
            public const string RESOLUTION_INDEX = "RESOLUTION_INDEX";
            public const string PLAYER_POSITION_X = "PLAYER_POSITION_X";
            public const string PLAYER_POSITION_Y = "PLAYER_POSITION_Y";
        }

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
        private const int DEFAULT_FULLSCREEN = 1;
        private static void LoadFullScreen()
        {
            ApplyFullScreen(
                PlayerPrefs.GetInt(PLAYER_PREF_KEYS.FULLSCREEN, DEFAULT_FULLSCREEN) == 1
            );
        }
        private static void SaveFullScreen(bool value)
        {
            ApplyFullScreen(value);
            PlayerPrefs.SetInt(PLAYER_PREF_KEYS.FULLSCREEN, fullScreen ? 1 : 0);
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
        private const float DEFAULT_VOLUME = .75f;
        private static void LoadVolume(AudioMixer audioMixer)
        {
            c_audioMixer = audioMixer;
            ApplyVolume(PlayerPrefs.GetFloat(PLAYER_PREF_KEYS.VOLUME, DEFAULT_VOLUME));
        }
        private static void SaveVolume(float value)
        {
            ApplyVolume(value);
            PlayerPrefs.SetFloat(PLAYER_PREF_KEYS.VOLUME, volume);
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
        private static void LoadResolution()
        {
            ResolutionOpions = Screen.resolutions;
            ApplyResolutionIndex(PlayerPrefs.GetInt(PLAYER_PREF_KEYS.RESOLUTION_INDEX, ResolutionOpions.Count() - 1));
        }
        private static void SaveResolutionIndex(int value)
        {
            ApplyResolutionIndex(value);
            PlayerPrefs.SetInt(PLAYER_PREF_KEYS.RESOLUTION_INDEX, resolutionIndex);
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

        #region PLAYER POSITION
        public static Vector3 PlayerPosition { get; private set; }
        private static void LoadPlayerPosition()
        {
            var hasKey = PlayerPrefs.HasKey(PLAYER_PREF_KEYS.PLAYER_POSITION_X) &&
                PlayerPrefs.HasKey(PLAYER_PREF_KEYS.PLAYER_POSITION_Y);
            if (hasKey)
            {
                PlayerPosition = new(
                    PlayerPrefs.GetFloat(PLAYER_PREF_KEYS.PLAYER_POSITION_X),
                    PlayerPrefs.GetFloat(PLAYER_PREF_KEYS.PLAYER_POSITION_Y)
                );
            }
        }
        private static void SavePlayerPosition(Vector3 value)
        {
            PlayerPrefs.SetFloat(PLAYER_PREF_KEYS.PLAYER_POSITION_X, value.x);
            PlayerPrefs.SetFloat(PLAYER_PREF_KEYS.PLAYER_POSITION_Y, value.y);
        }
        #endregion
    }
}
