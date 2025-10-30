using UnityEngine;

namespace Assets.App.Play.Ghost
{
    public class GhostVolume : MonoBehaviour
    {
        [SerializeField] private GameObject targetCamera;
        [SerializeField] private GameObject player;
        [SerializeField] private GameObject ghost;

        void Update()
        {
            transform.position = new Vector3(
                Vector3.Distance(player.transform.position, ghost.transform.position),
                targetCamera.transform.position.y,
                targetCamera.transform.position.z
            );
        }
    }
}
