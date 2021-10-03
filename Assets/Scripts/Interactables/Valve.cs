using System;
using UnityEngine;
using Mechanics;
using System.Collections;

public class Valve : MonoBehaviour, Interactable
{
    public void Interact(Action onInteractionDone)
    {
        StartCoroutine(RotateValve(onInteractionDone));
    }
    IEnumerator RotateValve(Action onRotationDone)
    {
        for (float t = 0; t < 1; t += Time.deltaTime)
        {
            transform.RotateAround(transform.position,  Vector3.right, Time.deltaTime*360);
            yield return new WaitForEndOfFrame();
        }
        onRotationDone?.Invoke();
    }
}
