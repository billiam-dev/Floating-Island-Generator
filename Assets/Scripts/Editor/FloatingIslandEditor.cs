using UnityEngine;
using UnityEditor;

namespace Billiam.FloatingIslands
{
    [CustomEditor(typeof(FloatingIsland), true)]
    public class FloatingIslandEditor : Editor
    {
        FloatingIsland floatingIsland;

        void OnEnable()
        {
            if (target is FloatingIsland) floatingIsland = (FloatingIsland)target;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (!floatingIsland)
            {
                return;
            }

            if (GUILayout.Button("Randomize Seed"))
            {
                floatingIsland.properties.seed = Random.Range(0, 1000000);
                floatingIsland.onUpdateProperties?.Invoke();
            }

            if (GUILayout.Button("Save As Schematic"))
            {
                floatingIsland.exporter.SaveAsSchematic(floatingIsland);
            }
        }
    }
}
