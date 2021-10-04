using System;
using UnityEngine;
using Mechanics;
using System.Collections;
using Audio;
using UnityEngine.Events;

public class Valve : MonoBehaviour, Interactable
{
    [SerializeField] float duration = 3f;
    [SerializeField] float rotationSpeed = 1f;
    [SerializeField] Vector3 multiplier = Vector3.right;
    [SerializeField] UnityEvent OnClose;

    public bool IsActive { get; set; } = true;

    Vector3 rotation;
    Vector3 offset;

    AudioLoopController audioLoop;

    private void Awake()
    {
        offset = transform.localEulerAngles;
        audioLoop = GetComponent<AudioLoopController>();
    }

    public void Interact(Action onInteractionDone)
    {
        StartCoroutine(RotateValve(onInteractionDone));
    }

    IEnumerator RotateValve(Action onRotationDone)
    {
        audioLoop?.Play();
        for (float t = 0; t < duration; t += Time.deltaTime)
        {
            SetRotation(t);
            yield return new WaitForEndOfFrame();
        }

        SetRotation(1f);

        if (CartController.Singleton != null)
            CartController.Singleton.remainingTasks--;
        IsActive = false;
        audioLoop?.Stop();
        onRotationDone?.Invoke();
        OnClose.Invoke();
    }

    void SetRotation(float time)
    {
        rotation = multiplier * time * rotationSpeed * 360f + offset;
        transform.localEulerAngles = rotation;
    }
}