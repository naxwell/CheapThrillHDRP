using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class wander : MonoBehaviour
{
    public Collider m_Collider;
    Vector3 m_Size, m_Min, m_Max;

    public float wanderTimer;

    private NavMeshAgent agent;
    private float timer;

    // Use this for initialization
    void OnEnable()
    {
        agent = GetComponent<NavMeshAgent>();
        m_Min = m_Collider.bounds.min;
        m_Max = m_Collider.bounds.max;
        timer = wanderTimer;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= wanderTimer)
        {
            Vector3 newPos = new Vector3(Random.Range(m_Min.x, m_Max.x), 0, Random.Range(m_Min.z, m_Max.z));
            agent.SetDestination(newPos);
            timer = 0;
        }
    }

}
