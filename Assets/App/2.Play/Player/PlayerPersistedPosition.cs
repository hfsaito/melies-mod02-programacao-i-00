using Assets.App.Common.Preferences;
using UnityEngine;

namespace Assets.App.Play.Player
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerPersistedPosition : MonoBehaviour
    {
        private Rigidbody2D c_rigidbody2d;

        void Awake()
        {
            c_rigidbody2d = GetComponent<Rigidbody2D>();
            if (PreferencesState.HasPlayerPosition)
            {
                c_rigidbody2d.MovePosition(PreferencesState.PlayerPosition);
            }
        }
        void OnDestroy()
        {
            PreferencesState.PlayerPosition = c_rigidbody2d.position;
        }
    }
}
