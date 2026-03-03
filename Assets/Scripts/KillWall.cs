using UnityEngine;

namespace AGDDPlatformer
{
    public class KillWall : MonoBehaviour
    {
        public float scrollSpeed = 3f;

        void Update()
        {
            if (GameManager.instance.timeStopped) return;
            transform.position += Vector3.right * scrollSpeed * Time.deltaTime;
        }

        void OnTriggerStay2D(Collider2D other)
        {
            PlayerController player = other.GetComponentInParent<PlayerController>();
            if (player != null)
            {
                player.ResetPlayer();
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