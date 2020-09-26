using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Align : MonoBehaviour
{

    public agent character;

    public agent target;

    private float maxAngularAcceleration = 5;

    private float maxRotation = 5;

    private float targetRadius = 2;

    private float slowRadius = 50;

    float timeToTarget = 0.1f;

    protected bool notAlign = false;

    protected float orientation;

    protected void functionAlign(){
        float rotation;
        if (notAlign == false){
            rotation = -Mathf.DeltaAngle(target.transform.eulerAngles.z, character.transform.eulerAngles.z) ;
        }  else {
            rotation = -Mathf.DeltaAngle(orientation, character.transform.eulerAngles.z) ;
        }  

        float rotationSize = Mathf.Abs(rotation);

        if (rotationSize > targetRadius){

            float targetRotation;
            if (rotationSize > slowRadius){
                targetRotation = maxRotation;
            } else {
                targetRotation = maxRotation * rotationSize / slowRadius;
            }

            targetRotation *= rotation / rotationSize;

            float result = targetRotation - character.rotation;

            result /= timeToTarget;

            float angularAcceleration = Mathf.Abs(result);

            if (angularAcceleration > maxAngularAcceleration){
                result /= angularAcceleration;
                result *= maxAngularAcceleration;
            } 

            
            character.steering.angular = result;
        }else {
            character.rotation = 0;
            character.steering.angular = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        functionAlign();

    }
}
