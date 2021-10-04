using System.Collections;
using UnityEngine;
using Mechanics;
using System;

public class OpenableInteractable : MonoBehaviour, Interactable
{
    [SerializeField] Animator anim;
    [SerializeField] string triggerName = "open";
    [SerializeField] float animationDuration = 0.25f;
    [SerializeField] UnityEngine.Events.UnityEvent OnBoxStartOpen;
    [SerializeField] Collider topCollider;

    public bool IsActive { get; set; } = true;

    public void Interact(Action onInteractionDone)
    {
        IsActive = false;
        StartCoroutine(WaitForAnimation(onInteractionDone));
    }

    IEnumerator WaitForAnimation(Action onInteractionDone)
    {
        OnBoxStartOpen.Invoke();
        anim?.SetTrigger(triggerName);
        yield return new WaitForSeconds(animationDuration);
        onInteractionDone?.Invoke();
        topCollider.enabled = false;
    }
}
