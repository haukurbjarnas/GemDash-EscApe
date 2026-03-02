using UnityEngine;

namespace AGDDPlatformer
{
    public class Laser : MonoBehaviour
    {
        [Header("Timing")]
        public float onDuration = 1.5f;    // how long the laser is ON (dangerous)
        public float offDuration = 1f;     // how long the laser is OFF (safe to pass)
        public float startOffset = 0f;     // stagger multiple lasers (0, 0.5, 1.0 etc.)

        [Header("Visuals")]
        public SpriteRenderer spriteRenderer;

        [Header("Colors")]
        public Color dangerColor = Color.red;
        public Color warningColor = new Color(1f, 0.5f, 0f); // orange = about to turn on

        bool isDangerous = true;
        float timer;
        BoxCollider2D col;

        void Awake()
        {
            col = GetComponent<BoxCollider2D>();
            timer = startOffset; // offset so lasers don't all blink in sync
        }

        void Update()
        {
            timer += Time.deltaTime;

            if (isDangerous)
            {
                // Show warning color in last 0.3s before turning off
                float timeLeft = onDuration - timer;
                spriteRenderer.color = timeLeft < 0.3f ? warningColor : dangerColor;

                col.enabled = true;

                if (timer >= onDuration)
                {
                    isDangerous = false;
                    timer = 0;
                    spriteRenderer.color = Color.grey;
                    col.enabled = false;
                }
            }
            else
            {
                // Flash orange as warning before turning back on
                float timeLeft = offDuration - timer;
                if (timeLeft < 0.4f)
                {
                    spriteRenderer.color = (Mathf.Sin(Time.time * 20f) > 0) 
                        ? warningColor : Color.grey;
                }

                if (timer >= offDuration)
                {
                    isDangerous = true;
                    timer = 0;
                    spriteRenderer.color = dangerColor;
                    col.enabled = true;
                }
            }
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            PlayerController player = other.GetComponentInParent<PlayerController>();
            if (player != null)
            {
                player.ResetPlayer();
            }
        }
    }
}