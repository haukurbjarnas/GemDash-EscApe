using UnityEngine;

namespace AGDDPlatformer
{
    public class KillZone : MonoBehaviour
    {
        void OnTriggerStay2D(Collider2D other)
        {
            TryKill(other);
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            PlayerController player = other.GetComponentInParent<PlayerController>();
            if (player != null)
            {
                player.ResetPlayer();
                FindObjectOfType<CameraAutoScroll>()?.ResetCamera();
                foreach (Laser laser in FindObjectsOfType<Laser>())
                    laser.ResetLaser();
            }
        }

        void TryKill(Collider2D other)
        {
            PlayerController player = other.GetComponentInParent<PlayerController>();
            if (player != null)
            {
                player.ResetPlayer();
                GetComponentInParent<CameraAutoScroll>().ResetCamera();
            }
        }
    }
}