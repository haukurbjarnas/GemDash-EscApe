using UnityEngine;

namespace AGDDPlatformer
{
    public class Spring : MonoBehaviour
    {
        public float launchForce = 20f;  // Tune this — ~20 feels great

        void OnCollisionEnter2D(Collision2D other)
        {
            PlayerController player = other.gameObject.GetComponentInParent<PlayerController>();
            if (player == null) return;

            // Only trigger when player lands on top of the spring
            ContactPoint2D[] contacts = new ContactPoint2D[other.contactCount];
            other.GetContacts(contacts);
            foreach (var contact in contacts)
            {
                if (contact.normal.y < -0.5f) // player is above spring
                {
                    // Override vertical velocity with big upward boost
                    player.velocity = new Vector2(player.velocity.x, launchForce);
                    return;
                }
            }
        }
    }
}