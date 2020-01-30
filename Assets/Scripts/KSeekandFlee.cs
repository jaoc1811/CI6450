using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KSeekandFlee : MonoBehaviour
{
    public bool mode;

    public agent character;

    public agent target;

    // Update is called once per frame
    void Update()
    {
        if(mode){

            character.velocity = target.transform.position - character.transform.position;
            
        } else{

            character.velocity = character.transform.position - target.transform.position;
        }
        character.velocity.Normalize();
        character.velocity *= character.maxSpeed;

        character.transform.rotation = character.newOrientation(character.transform.rotation,character.velocity);
    }
}
