using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerItem : MonoBehaviour
{

    public Transform target;
    public Rigidbody myRigidbody;

    void Update() {
        Vector3 direction = target.position - transform.position;
        myRigidbody.velocity = direction * Time.deltaTime*10;
    }
}
