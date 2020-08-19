using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Normal.Realtime;

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
    public Text powerUpText;

    [Header("Location Gen Stuff")]
    public Collider m_Collider;
    Vector3 m_Center;
    Vector3 m_Size, m_Min, m_Max;


    private RealtimeView _realtimeView;
    private RealtimeTransform _realtimeTrans;






    public gameController _gameController;
    // Start is called before the first frame update
    void Start()
    {
        availPowerUp = powerUps[Random.Range(0, powerUps.Length)];
        powerUpText.text = "Powerup Available Here: " + availPowerUp;

        _realtimeTrans = GetComponent<RealtimeTransform>();
        _realtimeView = GetComponent<RealtimeView>();

        //find min and max bound of floor collider for power up location generation 
        m_Min = m_Collider.bounds.min;
        m_Max = m_Collider.bounds.max;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter()
    {


        _realtimeTrans.RequestOwnership();
        _realtimeView.RequestOwnership();

        if (availPowerUp == "lightingControl")
        {
            _gameController._hasLightingControl = true;


        }

        if (availPowerUp == "lurker")
        {
            _gameController._hasLuker = true;
        }

        if (availPowerUp == "flashlightControl")
        {
            _gameController._hasFlashlightControl = true;
        }

        Vector3 newLoc = new Vector3(Random.Range(m_Min.x, m_Max.x), 0, Random.Range(m_Min.z, m_Max.z));
        transform.position = newLoc;
        availPowerUp = powerUps[Random.Range(0, powerUps.Length)];
        powerUpText.text = "Powerup Available Here: " + availPowerUp;



    }

    void OnTriggerExit()
    {
        _realtimeTrans.ClearOwnership();
        _realtimeView.ClearOwnership();
    }
}
