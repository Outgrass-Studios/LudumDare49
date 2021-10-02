using System.Collections.Generic;
using UnityEngine;

public static class CursorManager
{
    public static List<string> cursorStates = new List<string>();
    public static List<string> lookStates = new List<string>();
    public static List<string> movementStates = new List<string>();

    public static bool IsMouseLocked() =>
        cursorStates.Count == 0;

    public static bool CanMove() =>
        movementStates.Count == 0;

    public static bool CanLook() =>
        lookStates.Count == 0;

    [RuntimeInitializeOnLoadMethod]
    static void Initialize()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    public static void ChangeCursorState(string state, bool value)
    {
        switch(value)
        {
            case true:
                if (cursorStates.Contains(state))
                    cursorStates.Remove(state);
                break;
            default:
                if (!cursorStates.Contains(state))
                    cursorStates.Add(state);
                break;
        }
        Cursor.lockState = IsMouseLocked() ? CursorLockMode.Locked : CursorLockMode.None;
    }

    public static void ChangeLookState(string state, bool value)
    {
        switch (value)
        {
            case true:
                if (lookStates.Contains(state))
                    lookStates.Remove(state);
                break;
            default:
                if (!lookStates.Contains(state))
                    lookStates.Add(state);
                break;
        }
    }

    public static void ChangeMovementState(string state, bool value)
    {
        switch (value)
        {
            case true:
                if (movementStates.Contains(state))
                    movementStates.Remove(state);
                break;
            default:
                if (!movementStates.Contains(state))
                    movementStates.Add(state);
                break;
        }
    }

    public static void ChangeState(string state, bool value)
    {
        ChangeCursorState(state, value);
        ChangeLookState(state, value);
        ChangeMovementState(state, value);
    }
}