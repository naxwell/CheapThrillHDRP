using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class powerUp : MonoBehaviour
{
    [Header("Available Power Up")]
    public bool lurker;
    public bool lightingControl;
    public bool flashlightControl;
    public bool follower;
    public bool scream;

    private string[] powerUps = { "lurker", "lightingControl", "flashlightControl", "follower", "scream" };
    public string availPowerUp;

    public Canvas powerUpCanvas;





    public gameController _gameController;
    // Start is called before the first frame update
    void Start()
    {
        availPowerUp = powerUps[Random.Range(0, powerUps.Length)];
        //powerUpName.text = "Powerup Available Here: " + availPowerUp;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter()
    {
        _gameController._hasLightingControl = true;

        _gameController._hasLuker = true;
    }
}
