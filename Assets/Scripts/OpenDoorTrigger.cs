using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoorTrigger : MonoBehaviour
{


    public GameObject doorToOpen;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") {
            doorToOpen.SetActive(false);
        }
    }
}
