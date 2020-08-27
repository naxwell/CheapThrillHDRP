using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class volumeDelay : MonoBehaviour
{

    private AudioSource _as;
    public float delayTime = 2f;
    // Start is called before the first frame update
    void Start()
    {
        _as = GetComponent<AudioSource>();
        StartCoroutine(Delay());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator Delay()
    {
        yield return new WaitForSeconds(delayTime);
        _as.volume = 1f;
    }
}
