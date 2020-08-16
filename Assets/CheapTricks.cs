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

    public directLight _directLight;
    private Light _lightSource;
    private float _baseIntensity;

    [Header("Lurker")]
    public GameObject Lurker;
    public Transform Player;
    public float spawnDistance = 10f;



    public void Start()
    {
        _lightSource = directionalLight.GetComponent<Light>();
        _baseIntensity = _lightSource.intensity;

    }

    void Update()
    {



        if (Input.GetButtonDown("Fire2"))
        {
            if (isOn)
            {
                StartCoroutine(TurnOffLight());
                isOn = false;
            }
            else if (!isOn)
            {
                StartCoroutine(TurnOnLight());
                isOn = true;
            }
        }

        if (Input.GetButtonDown("Fire3"))
        {

            Vector3 playerPos = Player.position;
            playerPos.y = 0.5f;
            Vector3 playerDirection = Player.forward;
            Quaternion playerRotation = Player.localRotation;


            Vector3 LurkerLoc = playerPos + playerDirection * spawnDistance;
            Lurker.transform.position = LurkerLoc;

            Vector3 Targetposition = new Vector3(Player.position.x, 0.5f, Player.position.z);
            Lurker.transform.LookAt(Targetposition);

            Lurker.SetActive(true);
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
            float intens = Mathf.Lerp(_lightSource.intensity, Random.Range(_baseIntensity - MaxReduction, _baseIntensity + MaxIncrease), Strength * Time.deltaTime);
            _directLight.SetIntensity(intens);
            // _lightSource.intensity = Mathf.Lerp(_lightSource.intensity, Random.Range(_baseIntensity - MaxReduction, _baseIntensity + MaxIncrease), Strength * Time.deltaTime);
            yield return new WaitForSeconds(RateDamping);
        }

    }
    #endregion

}