using UnityEngine;

namespace AGDDPlatformer
{
    public class Laser : MonoBehaviour
    {
        [Header("Timing")]
        public float onDuration = 1.5f;
        public float offDuration = 1f;
        public float startOffset = 0f;

        [Header("Colors")]
        public Color dangerColor = Color.red;
        public Color warningColor = new Color(1f, 0.5f, 0f);

        bool isDangerous = true;
        float timer;
        BoxCollider2D col;
        SpriteRenderer sr;

        void Awake()
        {
            col = GetComponent<BoxCollider2D>();
            sr = GetComponent<SpriteRenderer>();
            timer = startOffset;
        }

        void Update()
        {
            timer += Time.deltaTime;

            if (isDangerous)
            {
                float timeLeft = onDuration - timer;
                sr.color = timeLeft < 0.3f ? warningColor : dangerColor;
                col.enabled = true;

                if (timer >= onDuration)
                {
                    isDangerous = false;
                    timer = 0;
                    sr.color = Color.grey;
                    col.enabled = false;
                }
            }
            else
            {
                float timeLeft = offDuration - timer;
                if (timeLeft < 0.4f)
                    sr.color = (Mathf.Sin(Time.time * 20f) > 0) ? warningColor : Color.grey;

                if (timer >= offDuration)
                {
                    isDangerous = true;
                    timer = 0;
                    sr.color = dangerColor;
                    col.enabled = true;
                }
            }
        }

        void OnCollisionEnter2D(Collision2D other)
        {
            PlayerController player = other.gameObject.GetComponentInParent<PlayerController>();
            if (player != null)
            {
                player.ResetPlayer();
                FindObjectOfType<CameraAutoScroll>()?.ResetCamera();
                foreach (Laser laser in FindObjectsOfType<Laser>())
                    laser.ResetLaser();
            }
        }

        public void ResetLaser()
        {
            timer = startOffset;
            isDangerous = true;
            col.enabled = true;
            sr.color = dangerColor;
        }
    }
}