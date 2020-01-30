using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KArrive : MonoBehaviour
{

    public agent character;

    public agent target;

    public float radius;

    public float timeToTarget;

    // Update is called once per frame
    void Update()
    {
        character.velocity = target.transform.position - character.transform.position;

        if (character.velocity.magnitude > radius){
            character.velocity /= timeToTarget;

            if (character.velocity.magnitude > character.maxSpeed){
                character.velocity.Normalize();
                character.velocity *= character.maxSpeed;
            }


        }
            character.transform.rotation = character.newOrientation(character.transform.rotation,character.velocity);
        
    }
}
