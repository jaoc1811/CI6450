using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{   

    public float rotation;

    public Vector3 velocity;

    public Vector3 gravity = new Vector3(0,0,-9.81f);


    // Update is called once per frame
    void Update()
    {
        transform.position += velocity * Time.deltaTime + (gravity * Time.deltaTime*Time.deltaTime) / 2;

        velocity += gravity*Time.deltaTime;

        if (velocity.z > 0){
            transform.localScale += new Vector3(0.1f,0.1f,0) ;
        } else{
            transform.localScale -= new Vector3(0.1f,0.1f,0) ;
        }

        if(transform.position.z < 0){
            Destroy(gameObject);
        }
    }
}
