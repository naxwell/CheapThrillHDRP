using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class activePlayerTest : MonoBehaviour
{

    public GameObject[] Players;
    public GameObject OwnedPlayer;
    // Start is called before the first frame update
    void Start()
    {
        Players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject players in Players)
        {

            RealtimeView _realtime = players.GetComponent<RealtimeView>();
            if (_realtime.isOwnedLocally)
            {

                OwnedPlayer = players;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
