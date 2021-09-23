using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabReleaseScript : MonoBehaviour
{
    public Transform player;

    public Transform playerCam;

    public float throwForce = 5;

    bool hasPlayer = false;

    bool beingCarried = false;

    // Update is called once per frame
    void Update()
    {
        float dist =
            Vector3.Distance(gameObject.transform.position, player.position);

        Debug.Log("dist: " + dist);

        if (dist < 10f)
        {
            hasPlayer = true;
        }
        else
        {
            hasPlayer = false;
        }

        if (hasPlayer && Input.GetButtonDown("Use"))
        {
            GetComponent<Rigidbody>().isKinematic = false;
            transform.parent = playerCam;
            beingCarried = true;
        }

        if (beingCarried)
        {
            if (Input.GetMouseButtonDown(0))
            {
                GetComponent<Rigidbody>().isKinematic = false;
                transform.parent = null;
                beingCarried = false;
            }
        }
    }
}
