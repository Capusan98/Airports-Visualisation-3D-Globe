using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectRotator : MonoBehaviour
{

    public float speed;
    private Vector3 rotationVector;
    // Start is called before the first frame update
    void Start()
    {
        rotationVector = new Vector3(0, speed, 0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotationVector, Space.World);
    }
}
