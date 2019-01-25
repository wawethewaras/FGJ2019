using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableObjectTrigger : MonoBehaviour
{

    public GameObject doorToOpen;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            doorToOpen.SetActive(true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Player")
        {
            doorToOpen.SetActive(true);
        }
    }
}
