using UnityEngine;
using qASIC;
using qASIC.InputManagement;

namespace Player
{
    public class PlayerMovementController : MonoBehaviour
    {
        CharacterController controller;

        [SerializeField] float speed;
        [SerializeField] float runSpeed;
        [SerializeField] float gravity;
        [SerializeField] float jumpHeight;
        [SerializeField] float groundVelocity = 3f;
        [SerializeField] Vector3 GroundPointOffset;
        [SerializeField] float GroundPointRadius = 0.55f;
        [SerializeField] LayerMask GroundLayer;

        float velocity;
        bool isGrounded;

        public static bool Noclip { get; set; }

        private void Awake()
        {
            controller = GetComponent<CharacterController>();
            if (controller == null)
                qDebug.LogError("Character controller has not been added!");
        }

        private void Update()
        {
            Vector3 path = GetPath();
            path.y += CalculateGravity();

            qDebug.DisplayValue("pos", VectorText.ToText(transform.position));
            qDebug.DisplayValue("path", VectorText.ToText(path));
            qDebug.DisplayValue("velocity", velocity);

            controller.Move(path * Time.deltaTime);
        }

        Vector3 GetPath()
        {
            if (!CursorManager.CanMove())
                return new Vector3();

            float y = InputManager.GetAxis("Up", "Down");
            float x = InputManager.GetAxis("Right", "Left");

            return (transform.right * x + transform.forward * y) * (InputManager.GetInput("Sprint") ? runSpeed : speed);
        }

        private void OnDrawGizmosSelected()
        {
            Color color = Gizmos.color;
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(transform.position + GroundPointOffset, GroundPointRadius);
            Gizmos.color = color;
        }

        float CalculateGravity()
        {
            isGrounded = Physics.CheckSphere(transform.position + GroundPointOffset, GroundPointRadius, GroundLayer);

            switch (Noclip)
            {
                case true:
                    velocity = InputManager.GetAxis("Jump", "Crouch") * (InputManager.GetInput("Sprint") ? runSpeed : speed);
                    break;
                default:
                    if (!isGrounded) return velocity -= gravity * Time.deltaTime;

                    velocity = -groundVelocity;
                    if (InputManager.GetInput("Jump") && CursorManager.CanMove())
                        velocity = Mathf.Sqrt(jumpHeight * 2f * gravity);
                    break;
            }
            return velocity;
        }
    }
}