using UnityEngine;

namespace Billiam.FloatingIslands
{
    public class VoxelArrayValidator : MonoBehaviour
    {
        [SerializeField] FloatingIsland island;
        [SerializeField] Vector3Int position;

        public string GetDebugText()
        {
            if (island == null)
            {
                return "No island selected";
            }

            if (island.voxels == null)
            {
                return "Voxel array is uninitialized";
            }

            if (position.x < 0 || position.x >= island.voxels.GetLength(0))
            {
                return "Voxel is out of bounds on the x axis";
            }

            if (position.y < 0 || position.y >= island.voxels.GetLength(1))
            {
                return "Voxel is out of bounds on the y axis";
            }

            if (position.z < 0 || position.z >= island.voxels.GetLength(2))
            {
                return "Voxel is out of bounds on the z axis";
            }

            return $"Voxel at position {position} is {island.voxels[position.x, position.y, position.z]}";
        }

        void OnDrawGizmosSelected()
        {
            Gizmos.color = new Color(1, 0, 0, 0.5f);
            Gizmos.DrawCube(transform.position + position, Vector3.one * 1.01f);
        }
    }
}
