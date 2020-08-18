using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightCollect : MonoBehaviour
{
    public gameController _gameController;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter()
    {
        _gameController._hasLightingControl = true;
    }
}
