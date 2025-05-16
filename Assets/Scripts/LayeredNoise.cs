using System;
using UnityEngine;

namespace Billiam.FloatingIslands
{
    [Serializable]
    public class LayeredNoise
    {
        [Min(0)]
        public float amplitude = 20f;
        [Min(0)]
        public float frequency = 0.05f;

        [Range(0, 1)]
        public float layer1AmplitudeMult = 0.5f;
        [Range(0, 2)]
        public float layer1FrequencyMult = 0.5f;
        [Range(0, 1)]
        public float layer2AmplitudeMult = 0.25f;
        [Range(0, 2)]
        public float layer2FrequencyMult = 0.25f;

        public float Sample(float x, float y, float seed, bool adjustRanges = false)
        {
            return PerlinNoise.Sample(amplitude, frequency, x, y, seed, adjustRanges) +
                   PerlinNoise.Sample(amplitude * layer1AmplitudeMult, frequency * layer1FrequencyMult, x + 52155, y + 42357, seed, adjustRanges) +
                   PerlinNoise.Sample(amplitude * layer2AmplitudeMult, frequency * layer2FrequencyMult, x + 266774, y + 38623, seed, adjustRanges);
        }
    }
}
