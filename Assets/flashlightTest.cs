using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashlightTest : MonoBehaviour
{
    [SerializeField]
    private float _power;
    private float _prevPower;

    private syncFlashlight _syncFlashlight;
    private Light _spotlight;
    // Start is called before the first frame update
    void Start()
    {
        _syncFlashlight = GetComponent<syncFlashlight>();
        _spotlight = GetComponent<Light>();
        _syncFlashlight.SetPower(80000f);
    }

    // Update is called once per frame
    void Update()
    {
        // if (_power != _prevPower)
        // {
        //     _syncFlashlight.SetPower(_power);
        //     _prevPower = _power;
        // }


    }

    public void flashlightFlip()
    {

        if (_spotlight.intensity == 0f)
        {
            _syncFlashlight.SetPower(80000f);
        }
        else if (_spotlight.intensity == 80000f)
        {
            _syncFlashlight.SetPower(0f);
        }
    }
}
