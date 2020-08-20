using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class screamTest : MonoBehaviour
{
    public bool _screamNow;
    public bool _lastScream;
    public AudioSource _as;

    private syncScream _syncScream;
    // Start is called before the first frame update
    void Start()
    {
        _as = GetComponent<AudioSource>();
        _syncScream = GetComponent<syncScream>();
    }

    // Update is called once per frame
    void Update()
    {


        if (_screamNow && !_lastScream)
        {
            //_syncScream.SetScream(true);
            _lastScream = true;
            _as.Play();

        }
        else if (_screamNow && _lastScream)
        {
            _syncScream.SetScream(false);
        }

        if (!_as.isPlaying)
        {
            _lastScream = false;
        }
    }

    public void Scream()
    {

        _syncScream.SetScream(true);
    }
}
