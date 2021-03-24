using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(XrayPoint))]
public class Pomo : Editor
{
    GUIStyle button;
    Texture logo;
    Vector3[] test = new Vector3[3];
    private void OnEnable()
    {
       
        test[0] = new Vector3(0, 0, 0);
        test[1] = new Vector3(0, 10, 0);
             test[2] = new Vector3(0, 0, 0);
        
        logo = Resources.Load("LOGO") as Texture;
    }

    public override void OnInspectorGUI()
    {
        XrayPoint myTarget = (XrayPoint)target;
        EditorGUILayout.LabelField("(Free vesion of Xray PlugIn !!)");
        EditorGUILayout.LabelField("(Buy The Pro vetion at )");
        EditorGUILayout.LabelField("(store.gargleblastergames.com )");

        if (GUILayout.Button(logo))
        {
            Application.OpenURL("https://gargleblastergames.com/xray/");
        }
        if (GUILayout.Button("Tutorials"))
        {
            Application.OpenURL("https://gargleblastergames.com/xray/");
        }
    }
  void OnSceneGUI()
    {
        // get the chosen game object
        XrayPoint t = target as XrayPoint;

        if( t == null || t.transform == null )
            return;
       
        // grab the center of the parent
        Vector3 center = t.transform.position;
        test[2] = center;
        Handles.Label(center, "this Is a Free Vetion !!");
      

    }
}
