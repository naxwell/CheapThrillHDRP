using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class Lurker : MonoBehaviour
{
    [Header("Lurker")]
    public GameObject[] Player;
    public GameObject OwnedPlayer;
    public float spawnDistance = 10f;


    private Transform lurkerHideout;
    private RealtimeTransform _realtimeTrans;
    private RealtimeView _realtimeView;
    private Transform controllerPlayer;




    // Start is called before the first frame update
    void Start()
    {
        _realtimeTrans = GetComponent<RealtimeTransform>();
        _realtimeView = GetComponent<RealtimeView>();
        lurkerHideout = GameObject.Find("Hideout").transform;

        OwnedPlayer = transform.parent.gameObject;
        transform.parent = null;
        //Player = GameObject.FindGameObjectsWithTag("Player");

    }

    // Update is called once per frame
    void Update()
    {
        // if (OwnedPlayer == null)
        // {
        //     Debug.Log("Null Player on lurkie");
        //     Player = GameObject.FindGameObjectsWithTag("Player");
        //     foreach (GameObject players in Player)
        //     {

        //         RealtimeView _realtime = players.GetComponent<RealtimeView>();
        //         if (_realtime.isOwnedLocally)
        //         {

        //             OwnedPlayer = players;
        //         }
        //     }
        // }


    }

    public void startLurk()
    {
        StartCoroutine(lurk());
    }



    public IEnumerator lurk()
    {


        _realtimeTrans.RequestOwnership();
        _realtimeView.RequestOwnership();
        //Player = GameObject.FindGameObjectsWithTag("Player");
        //controllerPlayer = Player[Random.Range(0, Player.Length)].transform;
        controllerPlayer = OwnedPlayer.transform;

        Vector3 playerPos = controllerPlayer.position;
        playerPos.y = 0.5f;
        Vector3 playerDirection = controllerPlayer.forward;
        Quaternion playerRotation = controllerPlayer.localRotation;


        Vector3 LurkerLoc = playerPos + playerDirection * spawnDistance;
        LurkerLoc.x = Random.Range(LurkerLoc.x - 5, LurkerLoc.x + 5);
        this.gameObject.transform.position = LurkerLoc;

        //Vector3 Targetposition = new Vector3(controllerPlayer.position.x, 0.5f, controllerPlayer.position.z);
        ///_lurker.transform.LookAt(Targetposition);
        this.gameObject.transform.rotation = Quaternion.LookRotation(controllerPlayer.transform.forward);

        //_lurker.SetActive(true);

        yield return new WaitForSeconds(3);
        this.gameObject.transform.position = lurkerHideout.position;
        yield return new WaitForSeconds(3);
        _realtimeTrans.ClearOwnership();
        _realtimeView.ClearOwnership();
    }
}
