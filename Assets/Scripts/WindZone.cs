using UnityEngine;

namespace AGDDPlatformer
{
    public class WindZone : MonoBehaviour
    {
        public Vector2 windForce = new Vector2(5f, 0f); // Push right by default
        // Use negative x for leftward wind, positive y for upward, etc.

        void OnTriggerStay2D(Collider2D other)
        {
            PlayerController player = other.GetComponentInParent<PlayerController>();
            if (player == null) return;

            // Apply wind as a velocity nudge each frame
            player.velocity += windForce * Time.deltaTime;
        }

        // Show the zone in the editor as a visible gizmo box
        void OnDrawGizmos()
        {
            Gizmos.color = new Color(0.5f, 0.8f, 1f, 0.3f);
            Gizmos.DrawCube(transform.position, transform.localScale);
        }
    }
}