using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;



[CustomEditor(typeof(generateForest))]

public class ForestGeneratorEditor : Editor
{


    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        generateForest myForestGenerator = (generateForest)target;

        if (GUILayout.Button("Generate Trees"))
        {

            myForestGenerator.generateTrees();
        }
        if (GUILayout.Button("Destroy Trees"))
        {

            myForestGenerator.destroyTrees();
        }

    }

}
