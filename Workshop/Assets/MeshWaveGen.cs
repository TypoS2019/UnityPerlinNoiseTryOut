using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshWaveGen : MonoBehaviour
{
    // Start is called before the first frame update
    public int xLength = 1;
    public int zLength = 1;
    public GameObject g;
    public List<GameObject> list;
    public float noiseOffsetX;
    public float noiseOffsetY;
    public float intensity = 1;
    public float speedX;
    public float speedY;

    void Start()
    {
        for (int i = 0; i < xLength; i++)
        {
            for (int j = 0; j < zLength; j++)
            {
                list.Add(Instantiate(g, new Vector3(i, genPerlinNoise(i,j), j), Quaternion.identity));
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        noiseOffsetX += speedX * Time.deltaTime;
        noiseOffsetY += speedY * Time.deltaTime;
    }

    public float genPerlinNoise(float x, float z)
    {
        float value = Mathf.PerlinNoise((x + noiseOffsetX) / intensity, (z + noiseOffsetY) / intensity) * 10;
        value += Mathf.PerlinNoise((x + -noiseOffsetX) / intensity * 2, (z + -noiseOffsetY) / intensity * 2) * 5;
        value += Mathf.PerlinNoise((x + noiseOffsetX + noiseOffsetY) / intensity * 3, (z + noiseOffsetY + noiseOffsetX) / intensity * 3);
        return value;
    }
}
