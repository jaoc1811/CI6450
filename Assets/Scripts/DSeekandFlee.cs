using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DSeekandFlee : MonoBehaviour
{
    public agent character;

    public agent target;

    public bool mode;

    protected bool avoid = false;

    protected Vector3 future = Vector3.zero;

    public void funcion(){

        if(avoid == false){
            if(mode){
                character.steering.linear = target.transform.position + future - character.transform.position;
            } else {
                character.steering.linear = character.transform.position - target.transform.position + future;
            }
        } else{
            character.steering.linear = future - character.transform.position;
        }

        character.steering.linear.Normalize();

        character.steering.linear *= character.maxAcceleration;
        

    }

    // Update is called once per frame
    void Update()
    {   
        funcion();
    }
}
