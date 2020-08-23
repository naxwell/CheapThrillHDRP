using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class syncScream : RealtimeComponent
{

    private screamTest _scream;
    private syncScreamModel _model;

    private AudioSource _audio;
    void Awake()
    {
        _scream = GetComponent<screamTest>();
        _audio = GetComponent<AudioSource>();
    }
    void Update()
    {

    }

    private syncScreamModel model
    {
        set
        {
            if (_model != null)
            {
                _model.screamDidChange -= ScreamDidChange;
            }
            _model = value;

            if (_model != null)
            {

                UpdateScreamBool();


                _model.screamDidChange += ScreamDidChange;
            }
        }
    }

    private void ScreamDidChange(syncScreamModel model, bool value)
    {
        UpdateScreamBool();
    }

    private void UpdateScreamBool()
    {
        _scream._screamNow = _model.scream;
        // if (_scream._screamNow)
        // {
        //_audio.Play();
        //}

    }

    public void SetScream(bool scream)
    {
        _model.scream = scream;
    }
}
