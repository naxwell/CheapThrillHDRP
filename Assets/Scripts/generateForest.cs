using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class generateForest : MonoBehaviour
{
    public Collider m_Collider;
    Vector3 m_Center;
    Vector3 m_Size, m_Min, m_Max;

    public GameObject[] treeFabs;
    public int numTrees = 0;
    public int maxTrees;

    public bool doneGenerating = false;
    public Transform ForestParent;

    void Start()
    {



    }

    void Update()
    {



        // if (numTrees == maxTrees)
        // {
        //     doneGenerating = true;
        //     numTrees = 0;
        // }
    }

    public void generateTrees()
    {
        //Fetch the center of the Collider volume
        m_Center = m_Collider.bounds.center;
        //Fetch the size of the Collider volume
        m_Size = m_Collider.bounds.size;
        //Fetch the minimum and maximum bounds of the Collider volume
        m_Min = m_Collider.bounds.min;
        m_Max = m_Collider.bounds.max;

        while (numTrees < maxTrees)
        {
            Vector3 treeLoc = new Vector3(Random.Range(m_Min.x, m_Max.x), 0, Random.Range(m_Min.z, m_Max.z));
            //Debug.Log(treeLoc);
            Collider[] hitColliders = Physics.OverlapBox(treeLoc, transform.localScale / 2, Quaternion.identity);
            //Debug.Log(hitColliders.Length);

            if (hitColliders.Length < 3)
            {
                Instantiate(treeFabs[Random.Range(0, treeFabs.Length)], treeLoc, Quaternion.identity, ForestParent);
                numTrees++;
            }
        }

    }

    public void destroyTrees()
    {
        GameObject[] trees = GameObject.FindGameObjectsWithTag("tree");

        for (var i = 0; i < trees.Length; i++)
        {
            DestroyImmediate(trees[i]);
        }

        numTrees = 0;
    }


}
