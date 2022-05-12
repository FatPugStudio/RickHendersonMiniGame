using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void Method ();
    public static event Method OnMethod;

    public delegate void DespawnEverything ();
    public static event DespawnEverything onDespawnEverything;

    void Start ()

    {
        if (OnMethod != null)
            OnMethod ();
    }

    public static void DespawnEverythingEvent ()

    {
        if (onDespawnEverything != null)
            onDespawnEverything ();
    }
}
