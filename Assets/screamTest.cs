using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;
public class screamTest : MonoBehaviour
{
    public bool _screamNow;
    public bool _lastScream;
    public AudioSource _as;
    private RealtimeView _realtime;

    private syncScream _syncScream;
    // Start is called before the first frame update
    void Start()
    {
        _as = GetComponent<AudioSource>();
        _syncScream = GetComponent<syncScream>();
        _realtime = GetComponent<RealtimeView>();
        //_realtime.RequestOwnership();
    }

    // Update is called once per frame
    void Update()
    {


        if (_screamNow && !_lastScream)
        {

            _realtime.RequestOwnership();
            StartCoroutine(Screaming());


        }

    }

    public IEnumerator Screaming()
    {
        _lastScream = true;
        //_as.Play();
        yield return new WaitForSeconds(2);
        _syncScream.SetScream(false);
        _lastScream = false;
        _realtime.ClearOwnership();

    }

    public void Scream()
    {
        //_realtime.RequestOwnership();
        _syncScream.SetScream(true);
        //_realtime.ClearOwnership();
    }
}
