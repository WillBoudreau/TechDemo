using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField]  private float speed = 12f;
    [SerializeField]  private float gravity = -9.81f;
    [SerializeField]  private int MinY = -15;
    [SerializeField]  private Vector3 positionY;
    [SerializeField]  private CharacterController CharacterCont;
    [SerializeField]  private float jumpHeight = 3f;
    [SerializeField]  private Transform groundCheck;
    [SerializeField]  private GameObject Bullet;
    public Vector3 StartPOS;
    public float groundDist = 0.4f;
    public LayerMask GroundMask;
    bool IsGrounded;
    Vector3 velocity;
    // Update is called once per frame
    void Start()
    {
        StartPOS = transform.position;
        CharacterCont = gameObject.GetComponent<CharacterController>();
        Debug.Log(StartPOS);
    }
    void Update()
    {
        IsGrounded = Physics.CheckSphere(groundCheck.position,groundDist,GroundMask);

        if(IsGrounded && velocity.y < 0)
        {
            velocity.y = -2.0f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        CharacterCont.Move(move * Time.deltaTime * speed);
        
        velocity.y += gravity * Time.deltaTime;

        CharacterCont.Move(velocity * Time.deltaTime * speed);
        //Jump if spacebar is pressed
        if(Input.GetKeyDown(KeyCode.Space) && IsGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        //Fire bullets
        if(Input.GetMouseButtonDown(0))
        {
           Instantiate(Bullet,transform.position,transform.rotation);
           Destroy(Bullet,5f);
        }
        //Crounch
        if(Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log("Crouch");
        }
        //Pause
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0.0f;
        }
        //Kill box
        if(velocity.y <= -15)
        {   
            transform.position = StartPOS;
        }
    }
        void OnTriggerEnter(Collider other)
        {
            //Collectable pickup
            if(other.gameObject.CompareTag("Collectable"))
            {
                Debug.Log("Hi");
            }
            if(other.gameObject.CompareTag("Checkpoint"))
            {
                Debug.Log("Checkpoint!");
                StartPOS = transform.position;
                Debug.Log(StartPOS);
            }
            if(other.gameObject.CompareTag("Teleporter"))
            {
                Debug.Log("Teleporter");
                transform.position += new Vector3(5f,0f,0f);
            }
        }
}
