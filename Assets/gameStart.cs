using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameStart : MonoBehaviour
{

    public GameObject mainCam;
    public GameObject _directionalLight;
    // Start is called before the first frame update
    void Start()
    {

        mainCam = GameObject.Find("mainCam");
        _directionalLight = GameObject.Find("Directional Light");
        mainCam.SetActive(false);
        _directionalLight.GetComponent<directLight>().SetIntensity(75);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
