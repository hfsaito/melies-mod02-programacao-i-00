using UnityEngine;

namespace Assets.App.Common.Pause
{
    public class PauseRoot : MonoBehaviour
    {
        void OnEnable()
        {
            Time.timeScale = 0;
        }

        void OnDisable()
        {
            Time.timeScale = 1;
        }

        void Start()
        {
            gameObject.SetActive(false);
        }
    }
}
