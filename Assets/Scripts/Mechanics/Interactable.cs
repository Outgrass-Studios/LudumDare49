using System;

namespace Mechanics
{
    internal interface Interactable
    {
        public bool IsActive { get; set; }
        public void Interact(Action onInteractionDone);
    }
}