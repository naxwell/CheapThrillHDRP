using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;

public class Lurker : MonoBehaviour
{
    [Header("Lurker")]
    public GameObject _lurker;
    public GameObject[] Player;
    public Transform controllerPlayer;
    public float spawnDistance = 10f;
    public Transform lurkerHideout;

    private RealtimeTransform _realtime;

    // Start is called before the first frame update
    void Start()
    {
        _realtime = GetComponent<RealtimeTransform>();

    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetButtonDown("Fire3") && _realtime.isOwnedByWorld)
        // {

        //     StartCoroutine(lurk());

        // }
    }

    public void startLurk()
    {
        StartCoroutine(lurk());
    }



    public IEnumerator lurk()
    {
        _realtime.RequestOwnership();
        Player = GameObject.FindGameObjectsWithTag("Player");
        controllerPlayer = Player[Random.Range(0, Player.Length)].transform;

        Vector3 playerPos = controllerPlayer.position;
        playerPos.y = 0.5f;
        Vector3 playerDirection = controllerPlayer.forward;
        Quaternion playerRotation = controllerPlayer.localRotation;


        Vector3 LurkerLoc = playerPos + playerDirection * spawnDistance;
        LurkerLoc.x = Random.Range(LurkerLoc.x - 5, LurkerLoc.x + 5);
        _lurker.transform.position = LurkerLoc;

        Vector3 Targetposition = new Vector3(controllerPlayer.position.x, 0.5f, controllerPlayer.position.z);
        _lurker.transform.LookAt(Targetposition);

        //_lurker.SetActive(true);

        yield return new WaitForSeconds(3);
        _lurker.transform.position = lurkerHideout.position;
        yield return new WaitForSeconds(3);
        _realtime.ClearOwnership();
    }
}
