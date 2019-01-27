using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(AudioSource))]
public class PlayerController : MonoBehaviour
{
    private Rigidbody myRidigbody;
    private AudioSource myAudioSource;

    // Start is called before the first frame update

    [SerializeField]
    private int movementSpeed;

    public float MouseSensitivity;


    public GameObject holder;


    public Image cursor;
    public Text gameText;

    void Start()
    {
        instance = this;
        myRidigbody = GetComponent<Rigidbody>();
        myAudioSource = GetComponent<AudioSource>();
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {

        Vector2 moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (moveInput != Vector2.zero)
        {
            myAudioSource.UnPause();
        }
        else {
            myAudioSource.Pause();

        }
        myRidigbody.MoveRotation(myRidigbody.rotation * Quaternion.Euler(new Vector3(0, Input.GetAxis("Mouse X") * MouseSensitivity, 0)));
        myRidigbody.MovePosition(transform.position + (transform.forward * moveInput.y * movementSpeed * Time.deltaTime) + (transform.right * moveInput.x * movementSpeed * Time.deltaTime));


        float rotationX = Head.transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;


        rotationY -= Input.GetAxis("Mouse Y") * sensitivityY;
        rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);

        Head.transform.localEulerAngles = new Vector3(rotationY, rotationX, 0);

        if (Physics.Raycast(transform.position, transform.forward, out hit, 10) && hit.collider.gameObject.tag == "carryObject")
        {

            cursor.color = Color.red;
            gameText.text = hit.collider?.gameObject?.GetComponent<RotateTowardPlayer>().text;
        }

        else if (hitObj != null) {
            cursor.color = Color.red;
            gameText.text = hitObj?.GetComponent<RotateTowardPlayer>().text;
        }
        else
        {
            cursor.color = Color.green;
            gameText.text = "";
        }
        if (Input.GetMouseButton(0))
        {
            if (hitObj == null && (hitObj = hit.collider?.gameObject?.GetComponent<Rigidbody>()) != null)
            {
                otherAudioSouce.PlayOneShot(audioClip);
                hitObj.useGravity = false;
            }
            if (hitObj != null) {
                //hitObj.transform.position = holder.transform.position;
                Vector3 movementDirection = new Vector3(holder.transform.position.x - hitObj.transform.position.x, holder.transform.position.y - hitObj.transform.position.y, holder.transform.position.z - hitObj.transform.position.z);
                hitObj.velocity = movementDirection * 10;
                //hitObj.useGravity = false;
            }

        }
        else if (hitObj != null)
        {
            hitObj.useGravity = true;

            hitObj = null;
            otherAudioSouce.PlayOneShot(audioClip);
        }

    }


    public Rigidbody hitObj;
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

    public AudioClip audioClip;
    public AudioSource otherAudioSouce;


    public GameObject winSCreen;
    public Text winScreenText;
    public string[] wingameTexts = {"Oh, is it done already? This is the first time I’ve done something like this all alone. If I can accomplish something like this I wonder what else I can do",
        "Oh, is it done already? It wasn't too bad after all, I did well! Now I’m going to relax in bubble bath", "Oh, is it done already? It wasn't too bad after all, I did well! Now I’m going to relax and watch that movie I was thinking about earlier. Maybe one of the Home alone movies... ",
        "Oh, is it done already? It wasn't too bad after all, I did well! Now I’m going to relax and watch that movie I was thinking about earlier. ",
        "Oh, is it done already? It wasn't too bad after all, I did well! I even have time for a evening walk and all. ",
        "Oh, is it done already? This is the first time I’ve done something like this all alone and I did well. I’m proud of myself!",
        "Oh, is it done already? It wasn't too bad after all, I did well! Now all I need is a cup of tea and a good book... " };


    static PlayerController instance;
    public static void WinGAme() {
        instance.StartCoroutine(startGame());
    }


    private static IEnumerator startGame() {
        yield return new WaitForSeconds(5f);
        instance.winSCreen.SetActive(true);
        int item = Random.Range(0, instance.wingameTexts.Length - 1);
        instance.winScreenText.text = instance.wingameTexts[item];

    }

}
