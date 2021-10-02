using qASIC.Options;
using UnityEngine;

namespace Player
{
    class PlayerSettings
    {
        [OptionsSetting("sensitivity", typeof(float))]
        public void ChangeSensitivity(float value) =>
            PlayerRotationController.MouseSensitivity = value;

        [OptionsSetting("fov", typeof(float))]
        public void ChangeFOV(float value)
        {
            value = Mathf.Clamp(value, 1f, 179f);
            CameraController.FOV = value;
            CameraController.OnFOVChange?.Invoke();
        }
    }
}