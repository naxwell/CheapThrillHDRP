using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class gameController : MonoBehaviour
{

    public GameObject Player;
    [Header("Lurker Shit")]
    public GameObject _lurker;
    public bool _hasLuker = false;
    private RealtimeTransform _lurkerRealtime;
    private Lurker _lurkScript;

    [Header("Direction Light Control")]

    public Light _lightSource;
    private syncLightFlicker _flickerScript;
    public bool _hasLightingControl = false;

    [Header("Flashlight Control")]
    public flashlightTest _flashlight;
    public bool _hasFlashlightControl = false;

    [Header("Scream Stuff")]

    public audioSync _audioSync;
    public bool _hasScreamControl;



    void Start()
    {
        _lurker = GameObject.Find("Lurker");
        _lurkerRealtime = _lurker.GetComponent<RealtimeTransform>();
        _lurkScript = _lurker.GetComponent<Lurker>();
        _flickerScript = _lightSource.GetComponent<syncLightFlicker>();



    }

    // Update is called once per frame
    void Update()
    {


        if (_flashlight == null)
        {
            _flashlight = Player.GetComponentInChildren<flashlightTest>();
            // _syncScream = Player.GetComponentInChildren<syncScream>();
            // _screamScript = Player.GetComponentInChildren<screamTest>();

        }

        if (_audioSync == null)
        {

            _audioSync = Player.GetComponentInChildren<audioSync>();
        }


        if (Input.GetButtonDown("xboxX") && _hasLuker)
        {
            _lurkScript.startLurk();

        }

        if (Input.GetButtonDown("xboxB") && _hasLightingControl)
        {
            if (_lightSource.intensity == 75)
            {
                StartCoroutine(_flickerScript.TurnOffLight());

            }
            else if (_lightSource.intensity == 0)
            {
                StartCoroutine(_flickerScript.TurnOnLight());

            }
        }

        if (Input.GetButtonDown("xboxY") && _hasFlashlightControl)
        {
            _flashlight.flashlightFlip();
        }

        if (Input.GetButtonDown("xboxA") && _hasScreamControl)
        {
            //_syncScream.SetScream(true);
            //_screamScript.Scream();
            //float random = Random.Range(0f, 1000f);
            _audioSync.SetRandomNumber(Random.Range(0f, 1000f));


        }
    }
}
