using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerItem : MonoBehaviour
{

    public Transform target;
    public Rigidbody myRigidbody;

    void Update() {
        if (Vector3.Distance(target.position, transform.position) >= 5) {
            Vector3 direction = target.position - transform.position;
            myRigidbody.velocity = direction * Time.deltaTime * 10;
        }

    }
}
