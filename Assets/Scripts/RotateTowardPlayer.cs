using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTowardPlayer : MonoBehaviour
{
    public Transform target;

    public string text;

    void Start()
    {
        if (text.Length <= 0) {
            text = gameObject.name;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 relativePos = target.position - transform.position;

        // the second argument, upwards, defaults to Vector3.up
        Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
        transform.rotation = rotation;
    }
}
