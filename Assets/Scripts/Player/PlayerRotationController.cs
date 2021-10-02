using UnityEngine;

namespace Player
{
    public class PlayerRotationController : MonoBehaviour
    {
        [SerializeField] Transform cam;
        Vector2 rotation;

        public static float MouseSensitivity { get; set; } = 1f;

        private void Awake()
        {
            rotation = new Vector2(transform.eulerAngles.y, cam.eulerAngles.x);
        }

        private void Update()
        {
            if (!CursorManager.IsMouseLocked() || !CursorManager.CanLook()) return;
            rotation.x += Input.GetAxis("Mouse X") * MouseSensitivity;
            rotation.y = Mathf.Clamp(rotation.y - Input.GetAxis("Mouse Y") * MouseSensitivity, -90f, 90f);
            ApplyRotation();
        }

        void ApplyRotation()
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, rotation.x, transform.eulerAngles.z);
            if (cam != null) cam.eulerAngles = new Vector3(rotation.y, cam.eulerAngles.y, cam.eulerAngles.z);
        }
    }
}