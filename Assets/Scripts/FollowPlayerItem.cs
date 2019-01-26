using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerItem : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            transform.SetParent(other.transform);
        }
    }
}
