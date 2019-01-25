using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableAndDisableObject : MonoBehaviour
{
    public GameObject ObjectToActivate;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            ObjectToActivate.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            ObjectToActivate.SetActive(false);
        }
    }
}
