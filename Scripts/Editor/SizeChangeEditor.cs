using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SizeChange))]
public class SizeChangeEditor : Editor {
    public SizeChange sizeChange
    {
        get
        {
            return (SizeChange)target;
        }
    }
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        if (GUILayout.Button("Static Hazard"))
        {
            sizeChange.sizeA = sizeChange.transform.localScale;
            sizeChange.sizeB = new Vector3(sizeChange.transform.localScale.x + 0.2f, sizeChange.transform.localScale.y - 0.2f);
            EditorUtility.SetDirty(sizeChange);
        }
    }
}
