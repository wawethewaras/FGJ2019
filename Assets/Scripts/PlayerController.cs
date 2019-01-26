using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody myRidigbody;
    // Start is called before the first frame update

    [SerializeField]
    private int movementSpeed;

    public float MouseSensitivity;


    public GameObject holder;


    public Image cursor;

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

        if (Physics.Raycast(transform.position, transform.forward, out hit, 10) && hit.collider.gameObject.tag == "carryObject")
        {
            if (Input.GetMouseButtonDown(0))
            {

                if (grabObj == false)
                {
                    hitObj = hit.collider.gameObject;
                    grabObj = true;
                }

            }
            cursor.color = Color.red;

        }
        else
        {
            cursor.color = Color.green;

        }
        if (grabObj && Input.GetMouseButton(0))
        {

            //Vector3 movementDirection = new Vector3(holder.transform.position.x - hitObj.transform.position.x, holder.transform.position.x - hitObj.transform.position.x, holder.transform.position.x - hitObj.transform.position.x);
            hitObj.transform.position = holder.transform.position;

        }
        else
        {
            grabObj = false;

        }

    }


    private bool grabObj = false;
    public GameObject hitObj;
    public RaycastHit hit;

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
