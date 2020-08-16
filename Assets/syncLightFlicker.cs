using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class syncLightFlicker : MonoBehaviour
{

    public bool turnOff = false;

    public float MaxReduction = 75f;
    public float MaxIncrease = 75f;
    public float RateDamping = 0.02f;
    public float Strength = 300f;
    bool StopFlickering = true;


    private Light _lightSource;
    private float _baseIntensity;


    private directLight _directLight;


    // Start is called before the first frame update
    void Start()
    {


        _directLight = GetComponent<directLight>();
        _lightSource = GetComponent<Light>();
        _baseIntensity = _lightSource.intensity;
        _directLight.SetIntensity(75f);

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire2"))
        {
            if (_lightSource.intensity == 75)
            {
                StartCoroutine(TurnOffLight());

            }
            else if (_lightSource.intensity == 0)
            {
                StartCoroutine(TurnOnLight());

            }
        }
    }

    private IEnumerator TurnOnLight()
    {
        StopFlickering = false;

        StartCoroutine(DoFlicker());
        yield return new WaitForSeconds(1);

        StopCoroutine(DoFlicker());
        _directLight.SetIntensity(75f);
        StopFlickering = true;


    }

    private IEnumerator TurnOffLight()
    {
        StopFlickering = false;
        StartCoroutine(DoFlicker());
        yield return new WaitForSeconds(1);
        _directLight.SetIntensity(0f);

        StopCoroutine(DoFlicker());
        StopFlickering = true;

    }

    private IEnumerator DoFlicker()
    {

        while (!StopFlickering)
        {
            float intens = Mathf.Lerp(_lightSource.intensity, Random.Range(_baseIntensity - MaxReduction, _baseIntensity + MaxIncrease), Strength * Time.deltaTime);
            _directLight.SetIntensity(intens);
            yield return new WaitForSeconds(RateDamping);
        }

    }
}
