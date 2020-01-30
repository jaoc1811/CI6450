using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Face : Align
{    

    protected Vector3 circlePosition;

    protected bool notFace = false;
    void Start(){
        notAlign = true;
    }

    protected void functionFace(){

        Vector3 direction;
        if(notFace == false){
            direction = target.transform.position - character.transform.position;
        }else{
            direction = circlePosition - character.transform.position;
        }

        // Debug.Log(direction);

        if(direction.magnitude != 0){
            
            orientation = Mathf.Atan2(-direction.x,direction.y) * Mathf.Rad2Deg;
            // Debug.Log(orientation);
            
        } else {
            character.rotation = 0;
            character.steering.angular = 0;
        }

        functionAlign();
    }
    // Update is called once per frame
    void Update()
    {   
        functionFace();
    }
}
