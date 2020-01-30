using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleAvoidance : DSeekandFlee
{
    public Collision[] collisions;

    public float avoidDistance; 

    public float lookahead;


    Collision GetCollision(Vector3 moveAmount){

        Collision result = new Collision();
        Vector3 ray = character.transform.position + moveAmount;

        foreach(Collision collision in collisions){

            Vector3 position = collision.transform.position;

            if(ray.x <= position.x + collision.rangeX && position.x - collision.rangeX <= ray.x){
                if(position.y - collision.rangeY <= ray.y && ray.y <= position.y + collision.rangeY){
                    result = collision;  
                    return result;      
                }
            }

        }

        return result;

    }

    void Start(){
        // avoid = true;
    }

    // Update is called once per frame
    void Update()
    {   
        Collision collision = new Collision();    
        Vector3 ray = character.velocity;
        ray.Normalize();
        ray *= lookahead;
        collision = GetCollision(ray);

        Debug.DrawLine(character.transform.position,character.transform.transform.position+ray,Color.red);
        if(collision){
            avoid = true;
            future = character.transform.position + ray + collision.normal * avoidDistance;
            funcion();
        }else{
            // avoid = false;
            // future = Vector3.zero;
        }


        
    }
}
