using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableAndDisableFilter : MonoBehaviour
{

    public GameObject filter;


    private void OnTriggerStay(Collider other)
    {
        if (!filter.activeSelf && other.tag == "Player")
        {
            filter.SetActive(true);

        }
    }
    private void OnTriggerExit(Collider other)
    {

        if (other.tag == "Player")
        {
            filter.SetActive(false);
        }

    }
}
