using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dollyZoom : MonoBehaviour
{
    public Camera mainCam;
    public bool zoom = false;

    public float maxFOV;
    public float minFOV;
    public float zoomSpeed = 0.01f;

    public float thrust = 1f;
    public GameObject playerBod;
    public Rigidbody rbPlayer;

    public CharacterController controller;
    public bool charPush;


    // Start is called before the first frame update
    void Start()
    {
        mainCam = GetComponent<Camera>();
        playerBod = transform.parent.gameObject;
        rbPlayer = playerBod.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (zoom)
        {
            //CameraZooming();
            //zoom = false;

        }

        if (Input.GetButtonDown("Right Bumper"))
        {
            zoom = true;
        }


        if (mainCam.fieldOfView >= minFOV + 3 && zoom)
        {
            var currentFoV = Mathf.Lerp(mainCam.fieldOfView, minFOV, zoomSpeed * Time.deltaTime);
            mainCam.fieldOfView = currentFoV;
            playerBod.GetComponent<CharacterController>().enabled = false;

            playerBod.transform.Translate(0, 0, -thrust * Time.deltaTime, Space.Self);
            //rbPlayer.AddForce(playerBod.transform.forward * thrust);
            charPush = true;



        }
        else if (mainCam.fieldOfView <= maxFOV)
        {
            zoom = false;
            var currentFoV = Mathf.Lerp(mainCam.fieldOfView, maxFOV, zoomSpeed * Time.deltaTime);
            mainCam.fieldOfView = currentFoV;
            playerBod.GetComponent<CharacterController>().enabled = true;

        }


        if (charPush)
        {
            // controller.Move(Vector3.forward * thrust);
            charPush = false;
        }

    }

    void CameraZooming()
    {


    }
}
