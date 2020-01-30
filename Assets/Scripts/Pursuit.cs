using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pursuit : DSeekandFlee
{
    public float maxPrediction;

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = target.transform.position - character.transform.position;
        float distance = direction.magnitude;

        float speed = character.velocity.magnitude;

        float prediction;
        if (speed <= distance / maxPrediction){
            prediction = maxPrediction;
        } else{
            prediction = distance / speed;
        }

        future = target.velocity * prediction;

        funcion();




    }
}
