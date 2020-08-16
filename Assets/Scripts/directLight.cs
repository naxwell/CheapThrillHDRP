using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class directLight : RealtimeComponent
{

    private directionalLightModel _model;
    private Light _light;

    void Start()
    {
        _light = GetComponent<Light>();
    }


    void Update()
    {

    }

    private directionalLightModel model
    {
        set
        {
            if (_model != null)
            {
                _model.intensityDidChange -= IntensityDidChange;
            }

            //store the model
            _model = value;

            if (_model != null)
            {

                UpdateLightIntensity();

                _model.intensityDidChange += IntensityDidChange;

            }

        }
    }

    private void IntensityDidChange(directionalLightModel model, float value)
    {
        //update light intensity
        UpdateLightIntensity();
    }

    private void UpdateLightIntensity()
    {
        //get the intensity from the model and set it to the light 
        _light.intensity = _model.intensity;
    }

    public void SetIntensity(float intensity)
    {
        _model.intensity = intensity;
    }
}
