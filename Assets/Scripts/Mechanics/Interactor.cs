using UnityEngine;
using qASIC.InputManagement;

namespace Mechanics
{
    public class Interactor : MonoBehaviour
    {
        public Transform source;
        [SerializeField] LayerMask mask;
        RaycastHit hit;

        void Update()
        {
            if (InputManager.GetInputDown("Interaction"))
            {
                if (Raycast())
                    if (hit.collider.gameObject.TryGetComponent(out Interactable interactable))
                    {
                        ChangeInputNumbness(true);
                        interactable.Interact(new System.Action(() =>
                        {
                            ChangeInputNumbness(false);
                        }));
                    }
            }
        }
        void ChangeInputNumbness(bool numb)
        {
            CursorManager.ChangeLookState("interact", !numb);
            CursorManager.ChangeMovementState("interact", !numb);
        }
        bool Raycast()
        {
            return source && Physics.Raycast(new Ray(source.position, source.forward), out hit, 10, mask);
        }
    }
}