using UnityEditor;

namespace Billiam.FloatingIslands
{
    [CustomEditor(typeof(VoxelArrayValidator), true)]
    public class VoxelArrayValidatorEditor : Editor
    {
        VoxelArrayValidator validator;

        void OnEnable()
        {
            validator = (VoxelArrayValidator)target;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            EditorGUILayout.LabelField(validator.GetDebugText());
        }
    }
}
