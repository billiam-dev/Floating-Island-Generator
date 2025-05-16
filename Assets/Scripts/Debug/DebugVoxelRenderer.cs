using UnityEngine;

namespace Billiam.FloatingIslands
{
    public class DebugVoxelRenderer : MonoBehaviour
    {
        [SerializeField] FloatingIsland floatingIsland;

        Voxel[,,] voxels;
        Vector3Int dimentions;

        void OnValidate()
        {
            if (floatingIsland)
            {
                voxels = floatingIsland.voxels;
                dimentions = new Vector3Int(voxels.GetLength(0), voxels.GetLength(1), voxels.GetLength(2));
            }
            else
            {
                voxels = null;
            }
        }

        void OnDrawGizmosSelected()
        {
            if (voxels == null)
            {
                return;
            }

            Gizmos.color = new Color(1, 0, 0);

            for (int x = 0; x < dimentions.x; x++)
            {
                for (int y = 0; y < dimentions.y; y++)
                {
                    for (int z = 0; z < dimentions.z; z++)
                    {
                        if (!VoxelIsAir(x, y, z) && AdjacentVoxelIsAir(x, y, z))
                        {
                            Gizmos.DrawCube(transform.position + new Vector3(x, y, z), Vector3.one);
                        }
                    }
                }
            }
        }

        bool AdjacentVoxelIsAir(int x, int y, int z)
        {
            if (VoxelIsAir(x + 1, y, z))
            {
                return true;
            }

            if (VoxelIsAir(x - 1, y, z))
            {
                return true;
            }

            if (VoxelIsAir(x, y + 1, z))
            {
                return true;
            }

            if (VoxelIsAir(x, y - 1, z))
            {
                return true;
            }

            if (VoxelIsAir(x, y, z + 1))
            {
                return true;
            }

            if (VoxelIsAir(x, y, z - 1))
            {
                return true;
            }

            return false;
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
    }
}
