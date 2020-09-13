using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class gameStart : MonoBehaviour
{

    public GameObject mainCam;
    public GameObject _directionalLight;
    public gameController _gamecontroller;
    public AudioListener _listener;
    private RealtimeView _realtime;
    public GameObject[] Offerings;
    // Start is called before the first frame update


    void Start()
    {

        Offerings = GameObject.FindGameObjectsWithTag("offering");
        foreach (GameObject offer in Offerings)
        {
            RealtimeTransform trans = offer.GetComponent<RealtimeTransform>();
            Debug.Log(trans.ownerID);
            if (trans.isOwnedByWorld)
            {
                trans.RequestOwnership();
            }

        }
        _directionalLight = GameObject.Find("Directional Light");

        _directionalLight.GetComponent<directLight>().SetIntensity(75);
        _gamecontroller = GetComponentInChildren<gameController>();

        //_gamecontroller.GetComponent<gameController>().Player = this.gameObject;
        mainCam = GameObject.Find("mainCam");
        if (mainCam != null)
        {
            mainCam.SetActive(false);
        }
        _realtime = GetComponent<RealtimeView>();
        _listener = GetComponentInChildren<AudioListener>();
        if (!_realtime.isOwnedLocally)
        {
            _listener.enabled = false;
        }

        // _listeners = FindObjectsOfType<AudioListener>();
        // foreach (AudioListener a in _listeners)
        // {
        //     a.enabled = false;
        // }
        // AudioListener al = GetComponentInChildren<AudioListener>();
        // al.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
