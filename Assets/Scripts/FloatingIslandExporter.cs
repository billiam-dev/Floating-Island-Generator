using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using Cyotek.Data.Nbt;

namespace Billiam.FloatingIslands
{
    // Thanks https://github.com/cyotek/Cyotek.Data.Nbt

    [Serializable]
    public class FloatingIslandExporter
    {
        [SerializeField] string path;
        [SerializeField, Tooltip("Copy me!")] string copyCommand;

        readonly Dictionary<Voxel, string> blockDictionary = new Dictionary<Voxel, string>()
        {
            { Voxel.Air, "minecraft:air" },
            { Voxel.Stone, "minecraft:stone" },
            { Voxel.Dirt, "minecraft:dirt" },
            { Voxel.Grass, "minecraft:grass_block" },
            { Voxel.Gravel, "minecraft:gravel" },
            { Voxel.Sand, "minecraft:sand" },
            { Voxel.Sandstone, "minecraft:sandstone" },
            { Voxel.CoalOre, "minecraft:coal_ore" },
            { Voxel.IronOre, "minecraft:iron_ore" },
        };

        public void SaveAsSchematic(FloatingIsland floatingIsland)
        {
            if (!Directory.Exists(path))
            {
                Debug.LogWarning("Could not create file, path does not exist");
            }

            string name = floatingIsland.name.Replace(" ", "");
            string saveAs = $"{path}/{name}.schem";

            MakeSchematic(floatingIsland).Save(saveAs);

            copyCommand = $"//schem load {name}";

            Debug.Log($"Saved to {saveAs}");
        }

        NbtDocument MakeSchematic(FloatingIsland floatingIsland)
        {
            Voxel[,,] voxels = floatingIsland.voxels;
            if (voxels == null)
            {
                Debug.LogWarning("Could not make schematic, voxel array is uninitialized");
                return null;
            }

            int width = voxels.GetLength(0);
            int height = voxels.GetLength(1);
            int length = voxels.GetLength(2);

            Dictionary<string, int> blockPalette = new Dictionary<string, int>();
            byte[] blockArray = new byte[width * height * length];

            NbtDocument document = new NbtDocument();
            TagCompound root = document.DocumentRoot;

            root.Name = "Schematic";

            // Schematic data
            TagCompound schematicTag = (TagCompound)root.Value.Add("Schematic", TagType.Compound);
            schematicTag.Value.Add("DataVersion", 4325);
            schematicTag.Value.Add("Version", 3);
            schematicTag.Value.Add("Height", (short)height);
            schematicTag.Value.Add("Length", (short)length);
            schematicTag.Value.Add("Width", (short)width);
            schematicTag.Value.Add("Offset", new int[3] { width / -2, height / -2 + 4, length / -2 });

            // Blocks tag
            TagCompound blocksTag = (TagCompound)schematicTag.Value.Add("Blocks", TagType.Compound);
            blocksTag.Value.Add("BlockEntities", new string[] { });

            // Make block pallete
            TagCompound paletteTag = (TagCompound)blocksTag.Value.Add("Palette", TagType.Compound);
            for (int y = 0; y < height; y++)
            {
                for (int z = 0; z < length; z++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        string tagName = blockDictionary[voxels[x, y, z]];
                        int blockID = (int)voxels[x, y, z];

                        if (!blockPalette.ContainsKey(tagName))
                        {
                            blockPalette.Add(tagName, blockID);
                            paletteTag.Value.Add(tagName, blockID);
                        }

                        int blockIndex = (y * length + z) * width + x;
                        blockArray[blockIndex] = (byte)blockID;
                    }
                }
            }

            blocksTag.Value.Add("Data", blockArray);

            return document;
        }
    }
}
