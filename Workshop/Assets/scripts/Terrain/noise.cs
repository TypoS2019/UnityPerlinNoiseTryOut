using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class noise
{
    public static float[,] GenerateNoiseMap(int mapHeight, int mapWidth, int seed, float scale, int octaves, float persistance, float lacunarity, Vector2 offset)
    {
        float[,] noiseMap = new float[mapWidth, mapHeight];

        System.Random prng = new System.Random(seed);
        Vector2[] octaveOffsets = new Vector2[octaves];
        for (int i = 0; i < octaves; i++)
        {
            float offSetX = prng.Next(-100000, 100000) + offset.x;
            float offSetY = prng.Next(-100000, 100000) + offset.y;
            octaveOffsets[i] = new Vector2(offSetX, offSetY);
        }

        if (scale <= 0)
        {
            scale = 0.0001f;
        }

        float highestValue = float.MinValue;
        float lowestValue = float.MaxValue;

        for(int x = 0; x < mapWidth; x++)
        {
            for(int z = 0; z < mapHeight; z++)
            {
                float amplitude = 1;
                float frequency = 1;
                float noiseHeight = 0;


                for (int i = 0; i < octaves; i++)
                {
                    float sampleX = x / scale * frequency + octaveOffsets[i].x;
                    float sampleZ = z / scale * frequency + octaveOffsets[i].y;
                    float perlinNoise = Mathf.PerlinNoise(sampleX, sampleZ) * 2 - 1;
                    noiseHeight += perlinNoise * amplitude;

                    amplitude *= persistance;
                    frequency *= lacunarity;
                }
                if(noiseHeight > highestValue)
                {
                    highestValue = noiseHeight;
                }
                else if(noiseHeight < lowestValue)
                {
                    lowestValue = noiseHeight;
                }

                noiseMap[x, z] = noiseHeight;
            }
        }

        for (int x = 0; x < mapWidth; x++)
        {
            for (int z = 0; z < mapHeight; z++)
            {
                noiseMap[x, z] = Mathf.InverseLerp(lowestValue, highestValue, noiseMap[x, z]);
            }
        }

                return noiseMap;
    }
}
