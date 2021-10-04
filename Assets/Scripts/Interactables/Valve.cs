using System;
using UnityEngine;
using Mechanics;
using System.Collections;

public class Valve : MonoBehaviour, Interactable
{
    [SerializeField] float duration = 3f;
    [SerializeField] float rotationSpeed = 1f;
    [SerializeField] Vector3 multiplier = Vector3.right;

    public bool IsActive { get; set; } = true;

    Vector3 rotation;
    Vector3 offset;

    private void Awake()
    {
        offset = transform.localEulerAngles;
    }

    public void Interact(Action onInteractionDone)
    {
        StartCoroutine(RotateValve(onInteractionDone));
    }

    IEnumerator RotateValve(Action onRotationDone)
    {
        for (float t = 0; t < duration; t += Time.deltaTime)
        {
            SetRotation(t);
            yield return new WaitForEndOfFrame();
        }

        SetRotation(1f);

        if (CartController.Singleton != null)
            CartController.Singleton.remainingTasks--;
        IsActive = false;
        onRotationDone?.Invoke();
    }

    void SetRotation(float time)
    {
        rotation = multiplier * time * rotationSpeed * 360f + offset;
        transform.localEulerAngles = rotation;
    }
}