using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightChangeTest : MonoBehaviour
{

    [SerializeField]
    private float _intensity;
    private float _prevIntesity;


    private directLight _directLight;

    // Start is called before the first frame update
    void Start()
    {
        _directLight = GetComponent<directLight>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_intensity != _prevIntesity)
        {
            _directLight.SetIntensity(_intensity);
            _prevIntesity = _intensity;
        }
    }
}
