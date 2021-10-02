using qASIC;
using UnityEngine;

namespace Player
{
    public class PlayerReference : MonoBehaviour
    {
        public static PlayerReference Singleton { get; private set; }

        public PlayerMovementController move;
        public PlayerRotationController look;
        public CameraController cam;

        private void Awake()
        {
            if (Singleton != null)
            {
                Destroy(gameObject);
                qDebug.LogWarning("There are multiple players in the scene!");
                return;
            }

            Singleton = this;
        }
    }
}