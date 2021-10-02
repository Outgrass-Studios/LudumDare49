using System.Collections.Generic;
using UnityEngine;

public static class CursorManager
{
    public static List<string> states = new List<string>();

    public static bool IsLocked() =>
        states.Count == 0;

    [RuntimeInitializeOnLoadMethod]
    static void Initialize()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    public static void ChangeState(string state, bool value)
    {
        switch(value)
        {
            case true:
                if (states.Contains(state))
                    states.Remove(state);
                break;
            default:
                if (!states.Contains(state))
                    states.Add(state);
                break;
        }
        Cursor.lockState = IsLocked() ? CursorLockMode.Locked : CursorLockMode.None;
    }
}