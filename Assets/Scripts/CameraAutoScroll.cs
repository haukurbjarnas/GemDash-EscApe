using UnityEngine;

namespace AGDDPlatformer
{
    public class CameraAutoScroll : MonoBehaviour
    {
        public float scrollSpeed = 3f;
        public bool isScrolling = true;

        void Update()
        {
            if (!isScrolling) return;
            if (GameManager.instance.timeStopped) return;

            transform.position += Vector3.right * scrollSpeed * Time.deltaTime;
        }
    }
}