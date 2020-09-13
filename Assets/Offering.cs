using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Normal.Realtime;


public class Offering : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GetComponent<RealtimeTransform>().RequestOwnership();
            other.gameObject.GetComponentInChildren<gameController>().hasOffering = true;

            transform.position = new Vector3(1, -5, 1);
        }
    }
}
