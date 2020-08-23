using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class audioSync : RealtimeComponent
{

    private AudioSource _audioSource;
    private audioSyncModel _model;
    // Start is called before the first frame update
    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private audioSyncModel model
    {
        set
        {

            if (_model != null)
            {
                _model.randomNumberDidChange -= RandomNumberDidChange;
            }
            _model = value;
            if (_model != null)
            {
                UpdateAudio();

                _model.randomNumberDidChange += RandomNumberDidChange;
            }
        }
    }
    private void RandomNumberDidChange(audioSyncModel model, float value)
    {
        UpdateAudio();
    }

    private void UpdateAudio()
    {
        _audioSource.Play();
    }
    public void SetRandomNumber(float number)
    {
        _model.randomNumber = number;
    }
}
