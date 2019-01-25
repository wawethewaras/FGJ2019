using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody myRidigbody;
    // Start is called before the first frame update

    [SerializeField]
    private int movementSpeed;

    void Start()
    {
        myRidigbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movementInput = new Vector3(Input.GetAxisRaw("Horizontal"),0, Input.GetAxisRaw("Vertical"));
        myRidigbody.velocity = movementInput.normalized * movementSpeed * Time.deltaTime;
    }
}
