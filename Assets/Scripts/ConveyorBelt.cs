using UnityEngine;

namespace AGDDPlatformer
{
    // Attach to any platform to make it a conveyor belt.
    // Positive speed = pushes right (speeds up rightward movement)
    // Negative speed = pushes left (slows down or reverses rightward movement)
    public class ConveyorBelt : MonoBehaviour
    {
        [Header("Belt Settings")]
        public float beltSpeed = 4f; 
        // Positive = pushes RIGHT (with auto-scroll = feels fast/dangerous)
        // Negative = pushes LEFT (against auto-scroll = slows you, very dangerous)

        public Color beltColor = new Color(0.8f, 0.6f, 0f); // amber/yellow

        SpriteRenderer sr;

        void Awake()
        {
            sr = GetComponent<SpriteRenderer>();
            if (sr != null) sr.color = beltColor;
        }

        void OnCollisionStay2D(Collision2D other)
        {
            PlayerController player = other.gameObject.GetComponentInParent<PlayerController>();
            if (player == null) return;

            // Only apply when player is standing on top
            foreach (ContactPoint2D contact in other.contacts)
            {
                if (contact.normal.y > 0.5f) // player is on top of belt
                {
                    player.velocity.x += beltSpeed * Time.deltaTime * 10f;
                    // Clamp so they don't accelerate forever
                    player.velocity.x = Mathf.Clamp(player.velocity.x, -20f, 20f);
                    return;
                }
            }
        }
    }
}