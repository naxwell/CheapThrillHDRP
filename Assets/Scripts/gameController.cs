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

    [Header("Crunch Stuff")]
    public audioSync _crunchSync;
    public bool _hasCrunchControl = false;

    [Header("Offering Stuff")]
    public bool hasOffering = false;
    public bool inOfferingZone = false;



    void Start()
    {
        //_lurker = GameObject.Find("Lurker");
        _lurker = transform.parent.GetChild(6).gameObject;
        _lurkerRealtime = _lurker.GetComponent<RealtimeTransform>();
        _lurkScript = _lurker.GetComponent<Lurker>();
        _lightSource = GameObject.Find("Directional Light").GetComponent<Light>(); ;
        _flickerScript = _lightSource.GetComponent<syncLightFlicker>();
        _audioSync = transform.parent.GetChild(3).GetComponent<audioSync>();
        _crunchSync = transform.parent.GetChild(4).GetComponent<audioSync>();
        Player = transform.parent.gameObject;



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

            // _audioSync = Player.GetComponentInChildren<audioSync>();
        }


        if (Input.GetButtonDown("xboxX") && _hasLuker)
        {
            _lurkScript.startLurk();

        }

        if (Input.GetButtonDown("xboxA") && _hasLightingControl)
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

        if (Input.GetButtonDown("xboxB") && _hasScreamControl)
        {
            //_syncScream.SetScream(true);
            //_screamScript.Scream();
            //float random = Random.Range(0f, 1000f);
            _audioSync.SetRandomNumber(Random.Range(0f, 1000f));


        }
        else if (Input.GetButtonDown("xboxB") && _hasCrunchControl)
        {
            _crunchSync.SetRandomNumber(Random.Range(0f, 1000f));
        }

        if (Input.GetButtonDown("xboxA") && hasOffering && inOfferingZone)
        {
            hasOffering = false;
            StartCoroutine(playerHighlight());
            Debug.Log("REVEAL OTHER PLAYERS");
        }
    }


    IEnumerator playerHighlight()
    {
        GameObject[] Players;
        Players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject player in Players)
        {
            player.GetComponentInChildren<MeshRenderer>().enabled = true;
        }

        yield return new WaitForSeconds(10);
        foreach (GameObject player in Players)
        {
            player.GetComponentInChildren<MeshRenderer>().enabled = false;
        }
    }
}
