using UnityEngine;

namespace AGDDPlatformer
{
    public class Spikes : MonoBehaviour
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