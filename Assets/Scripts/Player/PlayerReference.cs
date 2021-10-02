using qASIC;
using UnityEngine;
using Items;

namespace Player
{
    public class PlayerReference : MonoBehaviour
    {
        public static PlayerReference Singleton { get; private set; }

        public PlayerMovementController move;
        public PlayerRotationController look;
        public Inventory inventory;
        public CameraController cam;
        public PlayerCameraAnimator camAnimator;

        public static bool IsAnimated { get; set; }

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