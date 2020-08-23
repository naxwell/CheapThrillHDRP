using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime.Serialization;


[RealtimeModel]
public partial class audioSyncModel
{
    [RealtimeProperty(345, true, true)]
    private float _randomNumber;

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}

/* ----- Begin Normal Autogenerated Code ----- */
public partial class audioSyncModel : IModel {
    // Properties
    public float randomNumber {
        get { return _cache.LookForValueInCache(_randomNumber, entry => entry.randomNumberSet, entry => entry.randomNumber); }
        set { if (value == randomNumber) return; _cache.UpdateLocalCache(entry => { entry.randomNumberSet = true; entry.randomNumber = value; return entry; }); FireRandomNumberDidChange(value); }
    }
    
    // Events
    public delegate void RandomNumberDidChange(audioSyncModel model, float value);
    public event         RandomNumberDidChange randomNumberDidChange;
    
    // Delta updates
    private struct LocalCacheEntry {
        public bool  randomNumberSet;
        public float randomNumber;
    }
    
    private LocalChangeCache<LocalCacheEntry> _cache;
    
    public audioSyncModel() {
        _cache = new LocalChangeCache<LocalCacheEntry>();
    }
    
    // Events
    public void FireRandomNumberDidChange(float value) {
        try {
            if (randomNumberDidChange != null)
                randomNumberDidChange(this, value);
        } catch (System.Exception exception) {
            Debug.LogException(exception);
        }
    }
    
    // Serialization
    enum PropertyID {
        RandomNumber = 345,
    }
    
    public int WriteLength(StreamContext context) {
        int length = 0;
        
        if (context.fullModel) {
            // Mark unreliable properties as clean and flatten the in-flight cache.
            // TODO: Move this out of WriteLength() once we have a prepareToWrite method.
            _randomNumber = randomNumber;
            _cache.Clear();
            
            // Write all properties
            length += WriteStream.WriteFloatLength((uint)PropertyID.RandomNumber);
        } else {
            // Reliable properties
            if (context.reliableChannel) {
                LocalCacheEntry entry = _cache.localCache;
                if (entry.randomNumberSet)
                    length += WriteStream.WriteFloatLength((uint)PropertyID.RandomNumber);
            }
        }
        
        return length;
    }
    
    public void Write(WriteStream stream, StreamContext context) {
        if (context.fullModel) {
            // Write all properties
            stream.WriteFloat((uint)PropertyID.RandomNumber, _randomNumber);
        } else {
            // Reliable properties
            if (context.reliableChannel) {
                LocalCacheEntry entry = _cache.localCache;
                if (entry.randomNumberSet)
                    _cache.PushLocalCacheToInflight(context.updateID);
                
                if (entry.randomNumberSet)
                    stream.WriteFloat((uint)PropertyID.RandomNumber, entry.randomNumber);
            }
        }
    }
    
    public void Read(ReadStream stream, StreamContext context) {
        bool randomNumberExistsInChangeCache = _cache.ValueExistsInCache(entry => entry.randomNumberSet);
        
        // Remove from in-flight
        if (context.deltaUpdatesOnly && context.reliableChannel)
            _cache.RemoveUpdateFromInflight(context.updateID);
        
        // Loop through each property and deserialize
        uint propertyID;
        while (stream.ReadNextPropertyID(out propertyID)) {
            switch (propertyID) {
                case (uint)PropertyID.RandomNumber: {
                    float previousValue = _randomNumber;
                    
                    _randomNumber = stream.ReadFloat();
                    
                    if (!randomNumberExistsInChangeCache && _randomNumber != previousValue)
                        FireRandomNumberDidChange(_randomNumber);
                    break;
                }
                default:
                    stream.SkipProperty();
                    break;
            }
        }
    }
}
/* ----- End Normal Autogenerated Code ----- */
