using UnityEditor;

namespace Billiam.FloatingIslands
{
    [CustomEditor(typeof(FloatingIslandGenerator), true)]
    public class FloatingIslandGeneratorEditor : Editor
    {
        FloatingIslandGenerator generator;
        Editor islandEditor;

        void OnEnable()
        {
            generator = (FloatingIslandGenerator)target;
            generator.onIslandSelected += MakeSerizlizedObjectEditor;

            MakeSerizlizedObjectEditor();
        }

        void OnDisable()
        {
            generator.onIslandSelected -= MakeSerizlizedObjectEditor;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (islandEditor)
            {
                EditorGUILayout.BeginVertical("Box");
                EditorGUI.indentLevel++;
                islandEditor.OnInspectorGUI();
                EditorGUI.indentLevel--;
                EditorGUILayout.EndVertical();
            }

            serializedObject.ApplyModifiedProperties();
        }

        void MakeSerizlizedObjectEditor()
        {
            islandEditor = CreateEditor(generator.island);
        }
    }
}
