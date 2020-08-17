using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class CustomMouseLook : MonoBehaviour
{

    public float mouseSensitivity = 100f;
    public Transform PlayerBody;

    float xRotation = 0f;

    //Normcore stuff

    private RealtimeView _realtimeView;
    private RealtimeTransform _realtimeTransform;

    private void Awake()
    {
        _realtimeView = GetComponentInParent<RealtimeView>();
        _realtimeTransform = GetComponentInParent<RealtimeTransform>();
    }


    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyUp(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
        }

        // If this prefab is not owned by this client, bail.
        if (!_realtimeView.isOwnedLocally)
            return;


        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        PlayerBody.Rotate(Vector3.up * mouseX);
    }
}
