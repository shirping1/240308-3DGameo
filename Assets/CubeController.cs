using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    public float maxZ;
    public float minZ;
    public float maxX;
    public float minX;
    public float speed;

    float x = 1.0f;
    float z = 1.0f;
    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > maxZ)
        {
            x = -1.0f;
        }
        else if (transform.position.z < minZ)
        {
            x = 1.0f;
        }
        transform.position += new Vector3(0, 0, speed * x) * Time.deltaTime;

        if (transform.position.x > maxX)
        {
            z = -1.0f;
        }
        else if (transform.position.x < minX)
        {
            z = 1.0f;
        }
        transform.position += new Vector3(speed * z, 0, 0) * Time.deltaTime;
    }

}
