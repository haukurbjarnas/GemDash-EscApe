using UnityEngine;

namespace AGDDPlatformer
{
    public class CameraAutoScroll : MonoBehaviour
    {
        public float scrollSpeed = 3f;
        public bool isScrolling = true;

        Vector3 startPosition;

        void Start()
        {
            startPosition = transform.position;
        }

        void Update()
        {
            if (!isScrolling) return;

            transform.position += Vector3.right * scrollSpeed * Time.deltaTime;
        }

        public void ResetCamera()
        {
            transform.position = startPosition;
        }
    }
}