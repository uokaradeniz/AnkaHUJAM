using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomRotation : MonoBehaviour
{
    public float randomNumX;
    public float randomNumY;
    public float randomNumZ;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward, Random.Range(0, randomNumX));
        transform.Rotate(Vector3.right, Random.Range(0, randomNumY));
        transform.Rotate(Vector3.up, Random.Range(0, randomNumZ));
    }
}
