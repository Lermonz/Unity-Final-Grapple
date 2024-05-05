using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoolRotate : MonoBehaviour
{
    public float XRotate;
    public float YRotate;
    public float ZRotate;
    void Update()
    {
        transform.Rotate(new Vector3(XRotate,YRotate,ZRotate)*Time.deltaTime);
    }
}
