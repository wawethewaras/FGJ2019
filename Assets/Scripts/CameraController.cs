using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    void Update()
    {

        RaycastHit hit;
        var forward = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(transform.position, forward, out hit))
        {
            //Debug.Log("hit");

            if (hit.collider.CompareTag("hideObject"))
            {

                Debug.Log("hit", hit.transform);
                GameObject o = hit.collider.gameObject;
                o.GetComponent<Renderer>().enabled = false;
            }
            else
            {
                GameObject[] hides;
                hides = GameObject.FindGameObjectsWithTag("hideObject");

                // Iterate through them and turn each one off
                foreach (GameObject hide in hides)
                {
                    hide.GetComponent<Renderer>().enabled = true;
                }
            }

        }
    }
}
