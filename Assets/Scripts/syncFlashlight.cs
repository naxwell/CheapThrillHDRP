using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class syncFlashlight : RealtimeComponent
{

    private Light _spotlight;
    private flashlightModel _model;
    // Start is called before the first frame update
    void Awake()
    {
        _spotlight = GetComponent<Light>();
    }

    private flashlightModel model
    {
        set
        {

            if (_model != null)
            {
                _model.lightPowerDidChange -= LightPowerDidChange;

            }
            _model = value;

            if (_model != null)
            {
                UpdateFlashlightPower();

                _model.lightPowerDidChange += LightPowerDidChange;
            }
        }
    }

    private void LightPowerDidChange(flashlightModel model, float value)
    {
        UpdateFlashlightPower();
    }

    private void UpdateFlashlightPower()
    {
        _spotlight.intensity = _model.lightPower;
    }

    public void SetPower(float power)
    {
        _model.lightPower = power;
    }


}
