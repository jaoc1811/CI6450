using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{

    public Vector3 normal;

    public float rangeX;

    public float rangeY;

    void Start(){
        rangeX = transform.localScale.x / 2 + 0.5f;
        rangeY = transform.localScale.y / 2 + 0.5f;
    }

}
