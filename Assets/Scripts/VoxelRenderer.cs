using System.Collections.Generic;
using UnityEngine;

namespace Billiam.FloatingIslands
{
    // Adapted from: https://www.youtube.com/watch?v=ns78VoalB2A

    [ExecuteInEditMode, RequireComponent(typeof(MeshRenderer)), RequireComponent(typeof(MeshFilter))]
    public class VoxelRenderer : MonoBehaviour
    {
        class SubmeshRegister
        {
            class Submesh
            {
                public Material material;
                public List<int> triangles;

                public Submesh(Material material, List<int> triangles)
                {
                    this.material = material;
                    this.triangles = triangles;
                }
            }

            List<Submesh> submeshes;

            public SubmeshRegister()
            {
                submeshes = new List<Submesh>();
            }

            public void RegisterTriangle(List<int> triangles, Voxel voxelType, int faceNum)
            {
                Material material = GetFaceMaterial(voxelType, faceNum);

                // Try add to existing submesh
                foreach (Submesh submesh in submeshes)
                {
                    if (submesh.material == material)
                    {
                        submesh.triangles.AddRange(triangles);
                        return;
                    }
                }

                // Else, make new submesh
                submeshes.Add(new Submesh(material, triangles));
            }

            public void ApplySubmeshes(Mesh mesh)
            {
                for (int i = 0; i < submeshes.Count; i++)
                {
                    mesh.SetTriangles(submeshes[i].triangles, i);
                }
            }

            public Material[] GetSubmeshMaterials()
            {
                 Material[] materials = new Material[submeshes.Count];

                for (int i = 0; i < submeshes.Count; i++)
                {
                    materials[i] = submeshes[i].material;
                }

                return materials;
            }

            public int NumSubmeshes()
            {
                return submeshes.Count;
            }

            Material GetFaceMaterial(Voxel voxelType, int faceNum)
            {
                if (faceNum == 0)
                {
                    return materialRegistry[voxelType].TopMaterial;
                }
                else if (faceNum == 1)
                {
                    return materialRegistry[voxelType].BottomMaterial;
                }

                return materialRegistry[voxelType].SidesMaterial;
            }
        }

        class VoxelMeshGenerator
        {
            List<Vector3> vertices;
            List<int> triangles;
            List<Vector2> uv;
            SubmeshRegister submeshRegister;

            Voxel[,,] voxels;
            Vector3Int dimentions;

            int slice;

            readonly Vector3[] vertexPos = new Vector3[8]
            {
                new Vector3(-1, 1, -1), new Vector3(-1, 1, 1),
                new Vector3(1, 1, 1), new Vector3(1, 1, -1),
                new Vector3(-1, -1, -1), new Vector3(-1, -1, 1),
                new Vector3(1, -1, 1), new Vector3(1, -1, -1),
            };

            readonly int[,] faces = new int[6, 9]
            {
                {0, 1, 2, 3, 0, 1, 0, 0, 0},   // Top
                {7, 6, 5, 4, 0, -1, 0, 1, 0},  // Bottom
                {2, 1, 5, 6, 0, 0, 1, 1, 1},   // Right
                {0, 3, 7, 4, 0, 0, -1, 1, 1},  // Left
                {3, 2, 6, 7, 1, 0, 0, 1, 1},   // Front
                {1, 0, 4, 5, -1, 0, 0, 1, 1}   // Back
            };

            public VoxelMeshGenerator(Voxel[,,] voxels)
            {
                vertices = new List<Vector3>();
                triangles = new List<int>();
                uv = new List<Vector2>();
                submeshRegister = new SubmeshRegister();

                this.voxels = voxels;
                dimentions = new Vector3Int(voxels.GetLength(0), voxels.GetLength(1), voxels.GetLength(2));
            }

            public Material[] GetMaterials()
            {
                return submeshRegister.GetSubmeshMaterials();
            }

            public Mesh GetMesh()
            {
                for (int x = 0; x < dimentions.x; x++)
                {
                    for (int y = 0; y < dimentions.y; y++)
                    {
                        for (int z = 0; z < dimentions.z; z++)
                        {
                            TryAddQuads(x, y, z);
                        }
                    }
                }

                return MakeMesh();
            }

            public void SliceAt(int i)
            {
                slice = i;
            }

            void TryAddQuads(int x, int y, int z)
            {
                if (VoxelIsAir(x, y, z))
                {
                    // Skip this voxel
                    return;
                }

                for (int i = 0; i < 6; i++)
                {
                    if (VoxelIsAir(x + faces[i, 4], y + faces[i, 5], z + faces[i, 6]))
                    {
                        AddQuad(x, y, z, i, vertices.Count);
                    }
                }
            }

            void AddQuad(int x, int y, int z, int faceNum, int v)
            {
                for (int i = 0; i < 4; i++)
                {
                    vertices.Add(new Vector3(x, y, z) + vertexPos[faces[faceNum, i]] / 2f);
                }

                List<int> triangles = new List<int>() { v, v + 1, v + 2, v, v + 2, v + 3 };
                triangles.AddRange(triangles);
                submeshRegister.RegisterTriangle(triangles, voxels[x, y, z], faceNum);

                Vector2 bottomleft = new Vector2(faces[faceNum, 7], faces[faceNum, 8]);
                uv.AddRange(new List<Vector2>()
                {
                    bottomleft + new Vector2(0, 1),
                    bottomleft + new Vector2(1, 1),
                    bottomleft + new Vector2(1, 0),
                    bottomleft
                });
            }

            bool VoxelIsAir(int x, int y, int z)
            {
                if (x > dimentions.x - 1 - slice)
                {
                    return true;
                }

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

            Mesh MakeMesh()
            {
                Mesh mesh = new Mesh()
                {
                    indexFormat = UnityEngine.Rendering.IndexFormat.UInt32, // We need to be able to handle a shit-ton of vertices
                    vertices = vertices.ToArray(),
                    triangles = triangles.ToArray(),
                    uv = uv.ToArray(),
                    subMeshCount = submeshRegister.NumSubmeshes(),
                    name = "Floating Island"
                };

                submeshRegister.ApplySubmeshes(mesh);

                return mesh;
            }
        }

        class VoxelMaterials
        {
            public Material TopMaterial
            {
                get
                {
                    return Resources.Load<Material>(topPath);
                }
            }
            public Material BottomMaterial
            {
                get
                {
                    return Resources.Load<Material>(bottomPath);
                }
            }
            public Material SidesMaterial
            {
                get
                {
                    return Resources.Load<Material>(sidesPath);
                }
            }

            string topPath;
            string bottomPath;
            string sidesPath;

            public VoxelMaterials(string path)
            {
                topPath = path;
                bottomPath = path;
                sidesPath = path;
            }

            public VoxelMaterials(string top, string bottom, string sides)
            {
                topPath = top;
                bottomPath = bottom;
                sidesPath = sides;
            }
        }

        static readonly Dictionary<Voxel, VoxelMaterials> materialRegistry = new Dictionary<Voxel, VoxelMaterials>()
        {
            { Voxel.Air, new VoxelMaterials("Materials/Air") },
            { Voxel.Stone, new VoxelMaterials("Materials/Stone") },
            { Voxel.Dirt, new VoxelMaterials("Materials/Dirt") },
            { Voxel.Grass, new VoxelMaterials("Materials/Grass Top", "Materials/Dirt", "Materials/Grass Side") },
            { Voxel.Gravel, new VoxelMaterials("Materials/Gravel") },
            { Voxel.Sand, new VoxelMaterials("Materials/Sand") },
            { Voxel.Sandstone, new VoxelMaterials("Materials/Sandstone Top", "Materials/Sandstone Bottom", "Materials/Sandstone Side") },
            { Voxel.CoalOre, new VoxelMaterials("Materials/Coal Ore") },
            { Voxel.IronOre, new VoxelMaterials("Materials/Iron Ore") }
        };

        [SerializeField] FloatingIsland floatingIsland;
        [SerializeField, Min(0)] int slice;
        MeshFilter meshFilter;
        MeshRenderer meshRenderer;

        bool updateQueued;

        public void SetFloatingIsland(FloatingIsland floatingIsland)
        {
            this.floatingIsland = floatingIsland;
            floatingIsland.onUpdateVoxels += UpdateRenderer;
            updateQueued = true;
        }

        void UpdateRenderer()
        {
            //Debug.Log("UpdateRenderer");
            DestroyImmediate(meshFilter.sharedMesh);

            if (floatingIsland.voxels != null)
            {
                VoxelMeshGenerator meshGenerator = new VoxelMeshGenerator(floatingIsland.voxels);
                if (slice > 0)
                {
                    meshGenerator.SliceAt(slice);
                }

                meshFilter.sharedMesh = meshGenerator.GetMesh();
                meshRenderer.sharedMaterials = meshGenerator.GetMaterials();
            }
        }

        void Update()
        {
            if (updateQueued)
            {
                UpdateRenderer();
                updateQueued = false;
            }
        }

        void OnValidate()
        {
            if (meshFilter == null)
            {
                meshFilter = GetComponent<MeshFilter>();
            }

            if (meshRenderer == null)
            {
                meshRenderer = GetComponent<MeshRenderer>();
            }

            if (floatingIsland != null)
            {
                floatingIsland.onUpdateVoxels += UpdateRenderer;
                updateQueued = true;

                if (slice >= floatingIsland.properties.dimentions.x)
                {
                    slice = floatingIsland.properties.dimentions.x - 1;
                }
            }
        }
    }
}
