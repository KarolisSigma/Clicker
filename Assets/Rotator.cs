using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    private Transform tf;
    public float rotationSpeed=80;
    void Start()
    {
        tf =transform;
    }

    // Update is called once per frame
    void Update()
    {
        tf.Rotate(0,rotationSpeed*Time.deltaTime,0);
    }
}
