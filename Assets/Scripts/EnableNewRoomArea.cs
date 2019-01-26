using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableNewRoomArea : MonoBehaviour
{
    [SerializeField]
    private GameObject myRoomEnabler;
    [SerializeField]
    private GameObject myRoomToEnable;


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == myRoomEnabler)
        {
            myRoomToEnable.SetActive(true);
        }
    }
}
