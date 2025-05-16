/*using UnityEngine;
using UnityEditor;

namespace Billiam.FloatingIslands
{
    [CustomEditor(typeof(FloatingIslandExporter), true)]
    public class IslandExporterEditor : Editor
    {
        FloatingIslandExporter export;

        SerializedProperty floatingIslandProperty;
        SerializedProperty schematicNameProperty;
        SerializedProperty pathProperty;
        
        void OnEnable()
        {
            export = (FloatingIslandExporter)target;

            floatingIslandProperty = serializedObject.FindProperty("floatingIsland");
            schematicNameProperty = serializedObject.FindProperty("schematicName");
            pathProperty = serializedObject.FindProperty("path");
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(floatingIslandProperty);
            EditorGUILayout.PropertyField(pathProperty);
            //EditorGUILayout.PropertyField(outputProperty, GUIContent.none, GUILayout.Height(250));

            if (GUILayout.Button("Save As Schematic"))
            {
                export.SaveAsSchematic();
            }

            EditorGUILayout.PropertyField(schematicNameProperty);

            serializedObject.ApplyModifiedProperties();
        }
    }
}*/
