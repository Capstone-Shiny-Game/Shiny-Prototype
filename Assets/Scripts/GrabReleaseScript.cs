using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabReleaseScript : MonoBehaviour
{
    public Transform grabSource;

    bool hasPlayer = false;

    bool beingCarried = false;

    // Update is called once per frame
    void Update()
    {
        float dist =
            Vector3.Distance(gameObject.transform.position, grabSource.position);

        if (dist < 100f)
        {
            hasPlayer = true;
        }
        else
        {
            hasPlayer = false;
        }

        if (beingCarried)
        {
            transform.position = grabSource.position;
            transform.rotation = grabSource.rotation;

            if (Input.GetButtonDown("Use"))
            {
                GetComponent<Rigidbody>().isKinematic = false;
                transform.parent = null;
                beingCarried = false;
            }
        }
        else if (hasPlayer && Input.GetButtonDown("Use"))
        {
            GetComponent<Rigidbody>().isKinematic = true;
            transform.parent = grabSource;            
            beingCarried = true;
        }
    }
}
