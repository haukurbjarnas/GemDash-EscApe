using UnityEngine;

namespace AGDDPlatformer
{
    public class AutoScroll : MonoBehaviour
    {
        public float scrollSpeed = 3f;
        public Transform killWall; // assign a thin collider on the left edge

        void Update()
        {
            // Move the camera's target (and thus the visible world) to the right
            transform.position += Vector3.right * scrollSpeed * Time.deltaTime;
        }
    }
}