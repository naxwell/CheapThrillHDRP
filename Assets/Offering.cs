using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;


public class Offering : MonoBehaviour
{

    public Collider m_Collider;
    Vector3 m_Size, m_Min, m_Max;

    public float wanderTimer;
    private float timer;
    private bool isMoving = true;
    public bool isFollowing;
    public float followSpeed;
    public GameObject target;
    RealtimeTransform _realtimeTrans;
    RealtimeView _realtimeView;

    // Start is called before the first frame update
    void Start()
    {
        m_Min = m_Collider.bounds.min;
        m_Max = m_Collider.bounds.max;
        timer = wanderTimer;
        _realtimeTrans = GetComponent<RealtimeTransform>();
        _realtimeView = GetComponent<RealtimeView>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            transform.position += transform.forward * Time.deltaTime;
        }

        timer += Time.deltaTime;
        if (timer >= wanderTimer)
        {
            Vector3 newPos = new Vector3(Random.Range(m_Min.x, m_Max.x), 2.5f, Random.Range(m_Min.z, m_Max.z));
            transform.LookAt(newPos);
            timer = 0;
        }
        if (isFollowing && Vector3.Distance(transform.position, target.transform.position) > 0.1f)
        {
            transform.LookAt(target.transform.position);
            transform.position += transform.forward * followSpeed * Time.deltaTime;
        }

    }
    void OnTriggerEnter(Collider other)
    {

        gameController _gamecontrol = other.gameObject.GetComponentInChildren<gameController>();

        if (other.tag == "Player" && _gamecontrol.hasOffering == false)
        {
            _realtimeTrans.ClearOwnership();
            _realtimeView.ClearOwnership();
            _realtimeView.RequestOwnership();
            _realtimeTrans.RequestOwnership();
            _gamecontrol.hasOffering = true;
            _gamecontrol.currentOffering = this.gameObject;
            target = other.gameObject;
            isFollowing = true;
            // transform.parent = other.transform;
            // transform.localPosition = new Vector3(0, 0, 0);
            //transform.position = new Vector3(1, -5, 1);
            isMoving = false;

        }
    }

    void OnTriggerExit(Collider other)
    {

        if (!_realtimeTrans.isOwnedLocally)
        {
            other.gameObject.GetComponentInChildren<gameController>().hasOffering = false;
            other.gameObject.GetComponentInChildren<gameController>().currentOffering = null;
        }
    }
}
