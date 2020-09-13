using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public float jumpHeight = 3f;

    Vector3 velocity;
    bool isGrounded;
    public Vector3 prevPosition;
    private AudioSource _as;
    private float dist;

    public static Camera mainCam;
    //Normcore stuff

    private RealtimeView _realtimeView;
    private RealtimeTransform _realtimeTransform;

    private void Awake()
    {
        _realtimeView = GetComponent<RealtimeView>();
        _realtimeTransform = GetComponent<RealtimeTransform>();
        _as = GetComponent<AudioSource>();


    }

    void Start()
    {
        // if (mainCam == null)
        // {
        //     mainCam = GetComponentInChildren<Camera>();
        // }
        // else if (mainCam != this)
        // {
        //     mainCam.enabled = false;
        //     mainCam = GetComponentInChildren<Camera>();
        // }

        if (!_realtimeView.isOwnedLocally)
        {
            GetComponentInChildren<Camera>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

        // If this CubePlayer prefab is not owned by this client, bail.
        if (!_realtimeView.isOwnedLocally)
            return;

        // Make sure we own the transform so that RealtimeTransform knows to use this client's transform to synchronize remote clients.
        _realtimeTransform.RequestOwnership();

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {

            velocity.y = -2f;
        }
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);


        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

        }
        // dist = Vector3.Distance(prevPosition, transform.position);
        // if (dist < 0.01)
        // {

        //     _as.Pause();
        // }
        // else if (!_as.isPlaying)
        // {
        //     _as.Play();
        // }



        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        prevPosition = transform.position;
    }
}
