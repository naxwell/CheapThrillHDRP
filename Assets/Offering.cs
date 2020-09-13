using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

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
            other.gameObject.GetComponentInChildren<gameController>().hasOffering = true;
            GetComponent<NavMeshAgent>().enabled = false;
            transform.position = new Vector3(1, -5, 1);
        }
    }
}
