using UnityEngine;

public class SetCursorAwake : MonoBehaviour
{
    [SerializeField] string stateName = "global";
    [SerializeField] bool state;

    private void Awake()
    {
        CursorManager.ChangeCursorState(stateName, state);
    }
}