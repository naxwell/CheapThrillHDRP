using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followNotLooked : MonoBehaviour
{

    public Transform[] Players;
    public float speed = 1f;
    public bool move;

    Renderer m_Renderer;
    Transform target;


    // Start is called before the first frame update
    void Start()
    {
        m_Renderer = GetComponent<Renderer>();
        target = Players[Random.Range(0, Players.Length)];
    }

    // Update is called once per frame
    void Update()
    {
        if (!m_Renderer.isVisible)
        {
            move = true;
        }
        else
        {
            move = false;
        }

        float dist = Vector3.Distance(transform.position, target.position);

        if (move && dist > 2)
        {
            transform.LookAt(target);
            transform.position += transform.forward * Time.deltaTime * speed;
        }
    }
}
