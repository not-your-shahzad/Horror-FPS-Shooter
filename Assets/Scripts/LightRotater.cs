using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightRotater : MonoBehaviour
{
    public float rotateSpeed = 9.0f;

    void Update()
    {
        transform.Rotate(Vector3.forward*rotateSpeed *Time.deltaTime);
    }
}
