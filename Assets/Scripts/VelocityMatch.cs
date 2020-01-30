using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityMatch : MonoBehaviour
{
    public agent character;

    public agent target;

    public float maxAcceleration;

    private float timeToTarget = 0.1f;

    // Update is called once per frame
    void Update()
    {
        Vector3 linear = target.velocity - character.velocity;

        linear /= timeToTarget;

        if (linear.magnitude > maxAcceleration){
            linear.Normalize();
            linear *= maxAcceleration;

        }

        character.steering.linear = linear;
    }
}
