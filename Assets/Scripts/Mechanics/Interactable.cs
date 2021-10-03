using System;

namespace Mechanics
{
    internal interface Interactable
    {
        public void Interact(Action onInteractionDone);
    }
}