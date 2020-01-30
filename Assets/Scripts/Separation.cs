using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Separation : MonoBehaviour
{
    public agent character;

    public agent[] targets;

    public float thresold;

    public float decayCoefficient;


    // Update is called once per frame
    void Update()
    {   
        foreach(agent target in targets){
            Vector3 direction = character.transform.position - target.transform.position;
            float distance = direction.magnitude;

            if(distance < thresold){
                float strength = Mathf.Min(decayCoefficient / (distance*distance),character.maxAcceleration);

                direction.Normalize();

                character.steering.linear = strength * direction;
            }else{
                // character.steering.linear = Vector3.zero;
                // character.velocity = Vector3.zero;
            } 
        }
        
    }
}
