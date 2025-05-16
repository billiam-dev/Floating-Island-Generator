using System;
using UnityEngine;

namespace Billiam.FloatingIslands
{
    [CreateAssetMenu(fileName = "Floating Island")]
    public class FloatingIsland : ScriptableObject
    {
        public GeneratorProperties properties;
        public FloatingIslandExporter exporter;

        public Voxel[,,] voxels
        {
            get;
            private set;
        }

        // TODO: Serialized voxels as string so they are actually saved!

        public Action onUpdateVoxels;
        public Action onUpdateProperties;

        public void SetVoxels(Voxel[,,] voxels)
        {
            this.voxels = voxels;
            onUpdateVoxels?.Invoke();
        }

        void OnValidate()
        {
            onUpdateProperties?.Invoke();
        }
    }
}
