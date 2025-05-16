using System;
using System.Linq;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

[CreateAssetMenu(fileName = "LevelData", menuName = "Kris/LevelData")]
public class LevelData : ScriptableObject
{
    [HideInInspector]
    public Vector2 Size;
    [TextArea(minLines: 8, maxLines: 8)] 
    public string Content;
    
    
#if UNITY_EDITOR
    private void OnValidate()
    {
        String[] lines = Content.Split('\n');
        int x = lines.Max(x => x.Length);
        int y = lines.Length;
        Size = new Vector2(x, y);
    }
#endif
}


#if UNITY_EDITOR
[CustomEditor(typeof(LevelData))]
public class LevelDataEditor : Editor 
{
    SerializedProperty SizeProperty;
    

    public override void OnInspectorGUI()
    {
        SizeProperty = serializedObject.FindProperty("Size");
        GUI.enabled = false;
        EditorGUILayout.PropertyField(SizeProperty);
        GUI.enabled = true;
        base.OnInspectorGUI();
    }
}
#endif