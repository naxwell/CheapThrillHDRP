using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class syncScream : RealtimeComponent
{

    private screamTest _scream;
    private syncScreamModel _model;
    // Start is called before the first frame update
    void Start()
    {
        _scream = GetComponent<screamTest>();
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
    }

    public void SetScream(bool scream)
    {
        _model.scream = scream;
    }
}
