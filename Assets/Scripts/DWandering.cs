using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DWandering : Face
{
    
    private float wanderOffset = 4;

    private float wanderRadius = 2;

    private float wanderRate = 10;

    private float wanderOrientation = 0;

    

    void Start(){
        notFace = true;
        notAlign = true;
        wanderOrientation = character.transform.rotation.eulerAngles.z;
    }
    // Update is called once per frame
    void Update()
    {
        wanderOrientation += Random.Range(-1f,1f) * wanderRate;

        float targetOrientation = wanderOrientation + character.transform.rotation.z;

        circlePosition = character.transform.position + wanderOffset * character.asVector(character.transform.rotation.eulerAngles.z * Mathf.Deg2Rad);

        circlePosition += wanderRadius * character.asVector(targetOrientation * Mathf.Deg2Rad);

        character.steering.linear = character.maxAcceleration * character.asVector(character.transform.rotation.eulerAngles.z * Mathf.Deg2Rad);

        functionFace();
    }
}
