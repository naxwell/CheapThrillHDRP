using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Normal.Realtime;

public class powerUp : MonoBehaviour
{
    [Header("Available Power Up")]

    private string[] powerUps = { "lurker", "lightingControl", "flashlightControl", "scream", "crunch" };
    public string availPowerUp;
    private string prevPowerUp;

    public Canvas powerUpCanvas;
    public Text powerUpText;

    [Header("Location Gen Stuff")]
    public Collider m_Collider;
    Vector3 m_Center;
    Vector3 m_Size, m_Min, m_Max;


    private RealtimeView _realtimeView;
    private RealtimeTransform _realtimeTrans;


    public gameController _gameController;


    private AudioSource _as;
    // Start is called before the first frame update
    void Start()
    {
        availPowerUp = powerUps[Random.Range(0, powerUps.Length)];
        prevPowerUp = availPowerUp;
        powerUpText.text = "Powerup Available Here: " + availPowerUp;

        _realtimeTrans = GetComponent<RealtimeTransform>();
        _realtimeView = GetComponent<RealtimeView>();

        _as = GetComponent<AudioSource>();

        //find min and max bound of floor collider for power up location generation 
        m_Min = m_Collider.bounds.min;
        m_Max = m_Collider.bounds.max;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider collider)
    {

        _gameController = collider.gameObject.GetComponentInChildren<gameController>();
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

        if (availPowerUp == "scream")
        {
            _gameController._hasScreamControl = true;
            _gameController._hasCrunchControl = false;
        }

        if (availPowerUp == "crunch")
        {
            _gameController._hasScreamControl = false;
            _gameController._hasCrunchControl = true;
        }

        Vector3 newLoc = new Vector3(Random.Range(m_Min.x, m_Max.x), 0, Random.Range(m_Min.z, m_Max.z));
        transform.position = newLoc;


        _as.Play();

        StartCoroutine(NewPowerUp());


    }


    void OnTriggerExit()
    {


    }

    private IEnumerator NewPowerUp()
    {
        yield return new WaitForSeconds(2);
        availPowerUp = powerUps[Random.Range(0, powerUps.Length)];
        if (availPowerUp == prevPowerUp)
        {
            availPowerUp = powerUps[Random.Range(0, powerUps.Length)];
        }
        prevPowerUp = availPowerUp;
        powerUpText.text = "Powerup Available Here: " + availPowerUp;
        _realtimeTrans.ClearOwnership();
        _realtimeView.ClearOwnership();
    }
}
