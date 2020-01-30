using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionAvoidance : MonoBehaviour
{

    public agent character;

    public agent[] targets;

    public float radius;

    // Update is called once per frame
    void Update()
    {

        float shortestTime = Mathf.Infinity;

        agent firstTarget = null;
        float firstMinSeparation = 0;
        float firstDistance = 0;
        Vector3 firstRelativePos = Vector3.zero;
        Vector3 firstRelativeVel = Vector3.zero;

        foreach(agent target in targets){
            Vector3 relativePos = target.transform.position - character.transform.position;
            Vector3 relativeVel = target.velocity - character.velocity;
            float relativeSpeed = relativeVel.magnitude;
            float timeToCollision = Vector3.Dot(relativePos,relativeVel) / (relativeSpeed * relativeSpeed);

            float distance = relativePos.magnitude;
            float minSeparation = distance - relativeSpeed * timeToCollision;
            // print("timeToCollision: " + timeToCollision + " relativePos: " + relativePos + " relativeVel: "+ relativeVel + " relativeSpeed: " + relativeSpeed);
            print("minSeparation: " + minSeparation + " distance: " + distance + " relativeSpeed: " + relativeSpeed +" timeToCollision: " + timeToCollision);
            if (minSeparation <= 2 * radius){
                if(timeToCollision > 0 && timeToCollision < shortestTime){
                    shortestTime = timeToCollision;
                    firstTarget = target;
                    firstMinSeparation = minSeparation;
                    firstDistance = distance;
                    firstRelativePos = relativePos;
                    firstRelativeVel = relativeVel;
                }
            }
        }

        if(firstTarget){
            Debug.Log("entro");
            Vector3 relativePos;
            if(firstMinSeparation <= 0 || firstDistance < 2 * radius){
                Debug.Log("primera guardia");
                relativePos =  firstTarget.transform.position - character.transform.position;
            }else{
                Debug.Log("segunda guardia");
                relativePos = firstRelativePos + firstRelativeVel * shortestTime;
            }

            relativePos.Normalize();

            character.steering.linear = relativePos * character.maxAcceleration;
        }
        Debug.Log("salio");
    }
}
