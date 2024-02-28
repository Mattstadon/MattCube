using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Broadcaster : MonoBehaviour
{
    Transform receiver;
    // Start is called before the first frame update
    void Start()
    {
        receiver = GameObject.FindGameObjectWithTag("Receiver").transform;
        receiver.GetComponent<Animator>().SetTrigger("Dissolve");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
