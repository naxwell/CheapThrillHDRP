using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameStart : MonoBehaviour
{

    public GameObject mainCam;
    public GameObject _directionalLight;
    public GameObject _gamecontroller;
    // Start is called before the first frame update


    void Start()
    {


        _directionalLight = GameObject.Find("Directional Light");

        _directionalLight.GetComponent<directLight>().SetIntensity(75);
        _gamecontroller = GameObject.Find("Game Controller");

        _gamecontroller.GetComponent<gameController>().Player = this.gameObject;
        mainCam = GameObject.Find("mainCam");
        if (mainCam != null)
        {
            mainCam.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
