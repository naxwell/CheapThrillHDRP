using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class footsteps : MonoBehaviour
{
    public float dist;
    public Vector3 prevPosition;
    public AudioSource _as;
    // Start is called before the first frame update
    void Start()
    {
        _as = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        dist = Vector3.Distance(prevPosition, transform.position);
        if (dist < 0.01)
        {

            _as.Pause();
        }
        else if (!_as.isPlaying)
        {
            _as.Play();
        }
        prevPosition = transform.position;
    }
}
