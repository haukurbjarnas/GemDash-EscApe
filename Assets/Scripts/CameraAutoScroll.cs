using UnityEngine;
using Cinemachine;

namespace AGDDPlatformer
{
    // Attach to the CM vcam. Moves the follow target rightward automatically.
    // The camera follows this target, dragging the view with it.
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