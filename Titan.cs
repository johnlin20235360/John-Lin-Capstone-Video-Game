using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Titan : MonoBehaviour
{
    [Header("Button")]
    public float TitanScaleX;
    public float TitanScaleY;
    public float TitanScaleZ;
    private float startYScale;

    public KeyCode titanKey = KeyCode.Z;

    private void MyInput()
    {
        if (Input.GetKeyDown(titanKey))
        {
            transform.localScale = new Vector3(TitanScaleX, TitanScaleY, TitanScaleZ);
        }

        if (Input.GetKeyUp(titanKey))
        {
            transform.localScale = new Vector3(transform.localScale.x, startYScale, transform.localScale.z);
        }
    }
}
