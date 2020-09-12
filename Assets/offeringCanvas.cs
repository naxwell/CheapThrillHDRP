using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class offeringCanvas : MonoBehaviour
{
    public GameObject offerCanvas;
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

        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player in");
            offerCanvas.SetActive(true);
            other.gameObject.GetComponentInChildren<gameController>().inOfferingZone = true;
        }


    }


    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("Player Out");
            offerCanvas.SetActive(false);
            other.gameObject.GetComponentInChildren<gameController>().inOfferingZone = false;
        }
    }
}
