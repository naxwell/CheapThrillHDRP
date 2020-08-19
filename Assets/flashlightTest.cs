using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashlightTest : MonoBehaviour
{
    [SerializeField]
    private float _power;
    private float _prevPower;

    private syncFlashlight _syncFlashlight;
    // Start is called before the first frame update
    void Start()
    {
        _syncFlashlight = GetComponent<syncFlashlight>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_power != _prevPower)
        {
            _syncFlashlight.SetPower(_power);
            _prevPower = _power;
        }
    }
}
