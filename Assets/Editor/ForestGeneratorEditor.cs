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
        EditorGUILayout.HelpBox("make sure forest bounding box is not intersecting with any other colliders before generating", MessageType.Warning);

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
