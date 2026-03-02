using UnityEngine;

namespace AGDDPlatformer
{
    // Attach this to a tall invisible wall on the LEFT edge of the camera
    // Parent it to the camera so it moves with the scroll
    public class KillWall : MonoBehaviour
    {
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