using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyButton : MonoBehaviour
{
    [SerializeField] GameObject objectToDestroy;

    public void DestroyGameObject()
        {
            Destroy(objectToDestroy);
        }

    }