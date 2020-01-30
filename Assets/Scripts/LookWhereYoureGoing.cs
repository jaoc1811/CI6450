using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookWhereYoureGoing : Align
{   

    void Start(){
        notAlign = true;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 velocity = character.velocity;

        if (velocity.magnitude != 0){

            orientation = Mathf.Atan2(-velocity.x,velocity.y) * Mathf.Rad2Deg;
        } else {
            character.rotation = 0;
            character.steering.angular = 0;
        }

        functionAlign();
    }
}
