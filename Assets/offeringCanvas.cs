using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class offeringCanvas : MonoBehaviour
{
    public GameObject offerCanvas;
    public Text offeringText;

    public string hasOffering;
    public string noOffering;
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
            if (other.gameObject.GetComponentInChildren<gameController>().hasOffering)
            {
                offeringText.text = hasOffering;
            }
            else
            {
                offeringText.text = noOffering;
            }
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
