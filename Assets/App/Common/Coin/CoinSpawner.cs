using UnityEngine;

namespace Assets.App.Common.Coin
{
    [RequireComponent(typeof(RectTransform))]
    [RequireComponent(typeof(AudioSource))]
    public class CoinSpawner : MonoBehaviour
    {
        [SerializeField]
        private Coin prefab;
        [SerializeField]
        private int EXPECTED_COINS_IN_GAME;
        private Coin created;
        private int coinCounter = 0;
        private RectTransform c_rectTransform;

        private AudioSource c_audioSource;
        [SerializeField] private AudioClip coinAudioClip;

        void Start()
        {
            c_audioSource = GetComponent<AudioSource>();
            c_rectTransform = GetComponent<RectTransform>();
        }

        void FixedUpdate()
        {
            if (coinCounter < EXPECTED_COINS_IN_GAME)
            {
                coinCounter++;
                created = Instantiate(
                    prefab,
                    new Vector3(
                        transform.position.x + Random.Range(
                            -c_rectTransform.rect.width / 2,
                            c_rectTransform.rect.width / 2
                        ),
                        transform.position.y + Random.Range(
                            -c_rectTransform.rect.height / 2,
                            c_rectTransform.rect.height / 2
                        )
                    ),
                    new Quaternion()
                );
                created.OnDestroyEvent.AddListener(HandleCoinDestroyed);
            }
        }

        private void HandleCoinDestroyed()
        {
            coinCounter--;
            c_audioSource.PlayOneShot(coinAudioClip);
        }

        #region EDITOR
        void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            DrawRect();
        }

        void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            DrawRect();
        }

        private void DrawRect()
        {
            GetRectTransform();
            Gizmos.DrawWireCube(transform.position, new Vector3(c_rectTransform.rect.size.x, c_rectTransform.rect.size.y, .1f));
        }

        private void GetRectTransform()
        {
            if (c_rectTransform == null)
            {
                c_rectTransform = GetComponent<RectTransform>();
            }
        }
        #endregion
    }
}
