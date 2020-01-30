using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DArrive : MonoBehaviour
{
    public agent character;

    public agent target;

    public float targetRadius;

    public float slowRadius;

    private float timeToTarget = 0.1f;
     
    // Update is called once per frame
    void Update()
    {
        Vector3 direction = target.transform.position - character.transform.position;
        float distance = direction.magnitude;

        if (distance > targetRadius){
            float targetSpeed; 
            if (distance > slowRadius){
                targetSpeed = character.maxSpeed;
            } else {
                targetSpeed = character.maxSpeed * distance / slowRadius;
            }

            Vector3 targetVelocity = direction;
            targetVelocity.Normalize();
            targetVelocity *= targetSpeed;

            character.steering.linear = targetVelocity - character.velocity;
            character.steering.linear /= timeToTarget;

            if (character.steering.linear.magnitude > character.maxAcceleration){
                character.steering.linear.Normalize();
                character.steering.linear *= character.maxAcceleration;
            }
        } else {
            character.steering.linear = Vector3.zero;
            character.velocity =Vector3.zero;
        }

    }
}
