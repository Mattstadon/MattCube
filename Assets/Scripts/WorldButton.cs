using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WorldButton : MonoBehaviour
{
    [SerializeField] UnityEvent eventsToFire;

    private void OnMouseDown()
    {
        eventsToFire.Invoke();
    }
}
