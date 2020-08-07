using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheapTricks : MonoBehaviour
{

    public GameObject directionalLight;
    public GameObject flashlight;

    [Header("Light Flicker Setting")]
    public bool turnOff = false;
    public bool isOn = true;
    public float MaxReduction;
    public float MaxIncrease;
    public float RateDamping;
    public float Strength;
    bool StopFlickering = true;

    private Light _lightSource;
    private float _baseIntensity;




    public void Start()
    {
        _lightSource = directionalLight.GetComponent<Light>();
        _baseIntensity = _lightSource.intensity;

    }

    void Update()
    {



        if (isOn && turnOff)
        {
            StartCoroutine(TurnOffLight());
            isOn = false;
        }

        if (!isOn && !turnOff)
        {
            StartCoroutine(TurnOnLight());
            isOn = true;
        }

    }


    #region Light Stuff
    // default Light Flicker values 
    // MaxReduction = 0.2f;
    // MaxIncrease = 0.2f;
    // RateDamping = 0.1f;
    // Strength = 300;
    private IEnumerator TurnOnLight()
    {
        StopFlickering = false;
        _lightSource.enabled = true;
        StartCoroutine(DoFlicker());
        yield return new WaitForSeconds(1);

        StopFlickering = true;
        _lightSource.intensity = _baseIntensity;

    }
    private IEnumerator TurnOffLight()
    {
        StopFlickering = false;
        StartCoroutine(DoFlicker());
        yield return new WaitForSeconds(2);
        _lightSource.enabled = false;
        StopFlickering = true;

    }



    private IEnumerator DoFlicker()
    {

        while (!StopFlickering)
        {
            _lightSource.intensity = Mathf.Lerp(_lightSource.intensity, Random.Range(_baseIntensity - MaxReduction, _baseIntensity + MaxIncrease), Strength * Time.deltaTime);
            yield return new WaitForSeconds(RateDamping);
        }

    }
    #endregion

}