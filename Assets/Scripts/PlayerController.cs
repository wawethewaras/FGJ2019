using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody myRidigbody;
    // Start is called before the first frame update

    [SerializeField]
    private int movementSpeed;

    public float MouseSensitivity;

    void Start()
    {
        myRidigbody = GetComponent<Rigidbody>();
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        myRidigbody.MoveRotation(myRidigbody.rotation * Quaternion.Euler(new Vector3(0, Input.GetAxis("Mouse X") * MouseSensitivity, 0)));
        myRidigbody.MovePosition(transform.position + (transform.forward * Input.GetAxis("Vertical") * movementSpeed *Time.deltaTime) + (transform.right * Input.GetAxis("Horizontal") * movementSpeed * Time.deltaTime));


        float rotationX = Head.transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;


        rotationY -= Input.GetAxis("Mouse Y") * sensitivityY;
        rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

        Head.transform.localEulerAngles = new Vector3(rotationY, rotationX, 0);
    }

    public float sensitivityX = 15F;
    public float sensitivityY = 15F;

    public float minimumX = -360F;
    public float maximumX = 360F;
    public float minimumY = -60F;
    public float maximumY = 60F;

    public float viewRange = 60.0f;
    float rotationY = 0F;

    public GameObject Head;



  
}
