using qASIC;
using UnityEngine;
using System;

namespace Player
{
    public class CameraController : MonoBehaviour
    {
        Camera cam;

        public static float FOV { get; set; } = 60f;

        public static Action OnFOVChange;

        private void Awake()
        {
            cam = GetComponent<Camera>();
            if(cam == null)
            {
                qDebug.LogError("Camera has not assigned!");
                return;
            }

            OnFOVChange += UpdateFOV;
            UpdateFOV();
        }

        void UpdateFOV() =>
            cam.fieldOfView = FOV;

        private void OnDestroy() =>
            OnFOVChange -= UpdateFOV;
    }
}