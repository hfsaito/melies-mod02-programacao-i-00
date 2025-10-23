using UnityEngine;
using UnityEngine.Audio;

namespace Assets.App.Common.Preferences
{
    public class Preferences : MonoBehaviour
    {
        [SerializeField]
        private AudioMixer audioMixer;

        void Start()
        {
            PreferencesState.Load(audioMixer);
            Destroy(gameObject);
        }
    }
}
