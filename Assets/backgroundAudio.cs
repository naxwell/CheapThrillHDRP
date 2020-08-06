using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundAudio : MonoBehaviour
{

    public AudioClip[] backgrounds;
    AudioSource source;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if (!source.isPlaying)
        {
            playRandomBackground();
        }
    }

    public void playRandomBackground()
    {
        int clip = Random.Range(0, backgrounds.Length);
        source.clip = backgrounds[clip];
        source.Play();
    }
}
