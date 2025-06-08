using System;
using UnityEngine;

namespace Billiam.FloatingIslands
{
    [ExecuteInEditMode]
    public class FloatingIslandGenerator : MonoBehaviour
    {
        public FloatingIsland island;
        public Action onIslandSelected;
        VoxelRenderer voxelRenderer;
        bool regenerationQueued;

        class Generator
        {
            FloatingIsland island;
            Vector3Int dimentions;
            Voxel[,,] voxels;

            float[,] topNoiseValues;
            float[,] bottomNoiseValues;

            public Generator(FloatingIsland island)
            {
                this.island = island;
                dimentions = island.properties.dimentions;
                voxels = new Voxel[dimentions.x, dimentions.y, dimentions.z];

                topNoiseValues = new float[dimentions.x, dimentions.z];
                bottomNoiseValues = new float[dimentions.x, dimentions.z];

                DoShapePass();
                DoMaterialPass();
            }

            void DoShapePass()
            {
                for (int x = 0; x < dimentions.x; x++)
                {
                    for (int y = 0; y < dimentions.y; y++)
                    {
                        for (int z = 0; z < dimentions.z; z++)
                        {
                            CheckFillVoxel(x, y, z);
                        }
                    }
                }
            }

            void DoMaterialPass()
            {
                for (int x = 0; x < dimentions.x; x++)
                {
                    for (int y = 0; y < dimentions.y; y++)
                    {
                        for (int z = 0; z < dimentions.z; z++)
                        {
                            SetVoxelMaterial(x, y, z);
                        }
                    }
                }
            }

            void CheckFillVoxel(int x, int y, int z)
            {
                int centreX = dimentions.x / 2;
                int centreY = dimentions.y / 2;
                int centreZ = dimentions.z / 2;

                // Shape
                // Apply some noise to the centre positions to form the shape of the island
                float shapeNoise = island.properties.shapeNoise.Sample(x, z, island.properties.seed, true);

                float centreX_Warped = centreX + shapeNoise;
                float centreZ_Warped = centreZ + shapeNoise;

                float d = Mathf.Sqrt(Mathf.Pow(centreX_Warped - x, 2) + Mathf.Pow(centreZ_Warped - z, 2)); // Horizontal distance from centre
                if (d <= island.properties.radius)
                {
                    if (y >= centreY)
                    {
                        // Top
                        float noiseValue = island.properties.topLayer.Sample(x, z, island.properties.seed);

                        // Tend noise value towards zero on the outside of the island, dependent on the centre influence
                        if (island.properties.topCentreInfluence > 0)
                        {
                            noiseValue = Mathf.Lerp(noiseValue, 0, (d / island.properties.radius) * island.properties.topCentreInfluence);
                        }

                        // Apply layering
                        if (island.properties.layering > 0)
                        {
                            float layeredNoiseValue = Mathf.Floor(noiseValue * island.properties.layering) / island.properties.layering;
                            noiseValue = Mathf.Lerp(noiseValue, layeredNoiseValue, island.properties.layeredNoiseInfluence);
                        }

                        topNoiseValues[x, z] = noiseValue;

                        if (y <= noiseValue + centreY)
                        {
                            voxels[x, y, z] = Voxel.Stone;
                            return;
                        }
                    }
                    else
                    {
                        // Bottom
                        float noiseValue = island.properties.bottomLayer.Sample(x, z, island.properties.seed + 1440);

                        // Tend noise value towards zero on the outside of the island, dependent on the centre influence
                        if (island.properties.bottomCentreInfluence > 0)
                        {
                            noiseValue = Mathf.Lerp(noiseValue, 0, (d / island.properties.radius) * island.properties.bottomCentreInfluence);
                        }

                        bottomNoiseValues[x, z] = noiseValue;

                        if (centreY - y <= noiseValue)
                        {
                            voxels[x, y, z] = Voxel.Stone;
                            return;
                        }
                    }
                }

                voxels[x, y, z] = Voxel.Air;
            }

            void SetVoxelMaterial(int x, int y, int z)
            {
                if (VoxelIsAir(x, y, z))
                {
                    return;
                }

                voxels[x, y, z] = island.properties.rock.GetMaterial(x, y, z, island.properties.seed);

                int centreY = dimentions.y / 2;

                foreach (SurfaceMaterial surfaceMaterial in island.properties.surfaceLayers)
                {
                    if (y >= topNoiseValues[x, z] + centreY - surfaceMaterial.range.y && y <= topNoiseValues[x, z] + centreY - surfaceMaterial.range.x)
                    {
                        int k = island.properties.seed * x * z + 1251;
                        int randomNumber = (5245 * k + 2742) % 7919;

                        if (VoxelIsAir(x, y - 1, z) && randomNumber % 4 <= 2)
                        {
                            return;
                        }

                        if (VoxelIsAir(x, y - 2, z) && AdjacentToAir(x, y, z) && randomNumber % 3 == 0)
                        {
                            return;
                        }

                        voxels[x, y, z] = surfaceMaterial.materialLayer.GetMaterial(x, y, z, island.properties.seed);
                    }
                }
            }

            bool VoxelIsAir(int x, int y, int z)
            {
                if (x < 0 || x >= dimentions.x)
                {
                    return true;
                }

                if (y < 0 || y >= dimentions.y)
                {
                    return true;
                }

                if (z < 0 || z >= dimentions.z)
                {
                    return true;
                }

                return voxels[x, y, z] == Voxel.Air;
            }

            bool AdjacentToAir(int x, int y, int z)
            {
                if (VoxelIsAir(x + 1, y, z) || VoxelIsAir(x - 1, y, z) || VoxelIsAir(x, y, z + 1) || VoxelIsAir(x, y, z - 1))
                {
                    return true;
                }

                return false;
            }

            public Voxel[,,] GetVoxels()
            {
                return voxels;
            }
        }

        public void Generate()
        {
            Generator generator = new Generator(island);
            island.SetVoxels(generator.GetVoxels());
        }

        void Update()
        {
            if (regenerationQueued && island != null)
            {
                Generate();
                regenerationQueued = false;
            }
        }

        void QueueRegeneration()
        {
            regenerationQueued = true;
        }

        void OnValidate()
        {
            if (!voxelRenderer)
            {
                voxelRenderer = GetComponentInChildren<VoxelRenderer>();
            }

            if (voxelRenderer)
            {
                voxelRenderer.SetFloatingIsland(island);
            }

            onIslandSelected?.Invoke();

            island.onUpdateProperties += QueueRegeneration;
            QueueRegeneration();
        }

        void OnDrawGizmos()
        {
            if (island == null)
            {
                return;
            }

            Gizmos.color = new Color(0, 0.5f, 1, 0.5f);
            Vector3 centrePos = island.properties.dimentions / 2;

            Gizmos.DrawWireCube(centrePos, island.properties.dimentions);
        }
    }

    [Serializable]
    public struct GeneratorProperties
    {
        [Header("Basic Properties")]
        public Vector3Int dimentions;
        public int seed;

        [Header("Island Shape")]
        [Min(0)]
        public float radius;
        public LayeredNoise shapeNoise;

        [Min(0)]
        public float layering;
        [Range(0, 1)]
        public float layeredNoiseInfluence;

        [Header("Top")]
        public LayeredNoise topLayer;
        [Range(0, 1)]
        public float topCentreInfluence;

        [Header("Bottom")]
        public LayeredNoise bottomLayer;
        [Range(0, 1)]
        public float bottomCentreInfluence;

        [Header("Materials")]
        public SurfaceMaterial[] surfaceLayers;
        public MaterialLayer rock;
    }

    [Serializable]
    public class MaterialLayer
    {
        [Serializable]
        public struct Material
        {
            public Voxel voxelType;
            [Min(0)]
            public int weight;
        }

        public int totalWeight
        {
            get
            {
                int weight = 0;
                foreach (Material material in materials)
                {
                    weight += material.weight + 1;
                }

                return weight;
            }
        }

        public Material[] materials;

        public Voxel GetMaterial(int x, int y, int z, int seed)
        {
            if (materials == null || materials.Length == 0)
            {
                return Voxel.Stone;
            }

            int k = seed * x * y * z + 1251;
            int randomNumber = ((5245 * k + 2742) % 7919) % totalWeight;

            int cumulativeWeight = 0;
            foreach (Material material in materials)
            {
                cumulativeWeight += material.weight + 1;

                if (cumulativeWeight >= randomNumber)
                {
                    return material.voxelType;
                }
            }

            return Voxel.Air;
        }
    }

    [Serializable]
    public struct SurfaceMaterial
    {
        public MaterialLayer materialLayer;
        public Vector2Int range;
    }
}
