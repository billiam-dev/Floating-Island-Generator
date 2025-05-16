using System;
using UnityEngine;

namespace Billiam.FloatingIslands
{
    [Serializable]
    public class PerlinNoise
    {
        [Min(0)]
        public float amplitude = 10f;
        [Min(0)]
        public float frequency = 0.05f;

        public float Sample(float x, float y, float seed, bool adjustRange = false)
        {
            // Perlin noise always returns the same result for integers
            x += 0.1f;
            y += 0.1f;
            seed += 0.1f;

            float value = Mathf.PerlinNoise((x + seed) * frequency, (y + seed) * frequency) * amplitude;
            if (adjustRange)
            {
                value -= amplitude * 0.5f;
            }

            return value;
        }

        public static float Sample(float amplitude, float frequency, float x, float y, float seed, bool adjustRange = false)
        {
            x += 0.1f;
            y += 0.1f;
            seed += 0.1f;

            float value = Mathf.PerlinNoise((x + seed) * frequency, (y + seed) * frequency) * amplitude;
            if (adjustRange)
            {
                value -= amplitude * 0.5f;
            }

            return value;
        }
    }
}
