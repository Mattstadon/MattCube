using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastLine : MonoBehaviour
{
    [SerializeField] LayerMask layerMask;
    [SerializeField] float laserDistance = 100;
    [SerializeField] GameObject hitEffect;
    [SerializeField] float effectOffsetAmount = .1f;
    LineRenderer line;

    // Start is called before the first frame update
    void Start()
    {
        line = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        line.SetPosition(0, transform.position);
        line.SetPosition(1, transform.position + transform.forward * laserDistance);

        RaycastHit hit;
        if (Physics.Raycast(transform.position,transform.forward,out hit, laserDistance, layerMask))
        {
            //if (hit.transform.tag == "Cube")
            line.SetPosition(1, hit.transform.position);


            if (hitEffect != null)
            {
                hitEffect.SetActive(true);
                hitEffect.transform.position = hit.point;
                hitEffect.transform.position += hit.normal * effectOffsetAmount;
            }
        }
        else
        {
            if (hitEffect != null)
            {
                hitEffect.SetActive(false);
            }
        }
    }
}
