using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class gameController : MonoBehaviour
{

    [Header("Lurker Shit")]
    public GameObject _lurker;
    public bool _hasLuker = false;
    private RealtimeTransform _lurkerRealtime;
    private Lurker _lurkScript;

    [Header("Direction Light Control")]

    public Light _lightSource;
    private syncLightFlicker _flickerScript;
    public bool _hasLightingControl = false;
    // Start is called before the first frame update

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
        if (Input.GetButtonDown("Fire3") && _hasLuker)
        {
            _lurkScript.startLurk();

        }

        if (Input.GetButtonDown("Fire2") && _hasLightingControl)
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

    }
}
