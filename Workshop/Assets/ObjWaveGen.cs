using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjWaveGen : MonoBehaviour
{
    [SerializeField] public MeshWaveGen container;
    public float test;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.SetPositionAndRotation(new Vector3(transform.position.x, container.genPerlinNoise(transform.position.x, transform.position.z), transform.position.z), new Quaternion());
    }
}
