using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{   

    public float rotation;

    public Vector3 velocity;

    public Vector3 gravity = new Vector3(0,0,-9.81f);

    public Sprite puke;

    // Update is called once per frame
    void Update()
    {
        transform.position += velocity * Time.deltaTime + (gravity * Time.deltaTime*Time.deltaTime) / 2;

        velocity += gravity*Time.deltaTime;

        if (velocity.z > 0){
            transform.localScale += new Vector3(0.1f,0.1f,0) ;
        } else if(velocity.z < 0){
            transform.localScale -= new Vector3(0.1f,0.1f,0) ;
        }

        if(transform.position.z > 0 && transform.position.z < 0.2){
            foreach(Node node in GameObject.Find("manuelito").GetComponent<PathFinding>().graph.nodes.Values){
                if(GameObject.Find("manuelito").GetComponent<PathFinding>().graph.PointInTriangle(new Vector3(transform.position.x,transform.position.y,0), node.vertices)){
                    velocity = Vector3.zero;
                    gravity = Vector3.zero;
                    transform.position = new Vector3(transform.position.x,transform.position.y,0);
                    GetComponent<SpriteRenderer>().sprite= puke;
                    GetComponent<SpriteRenderer>().sortingLayerName = "alfombras";
                }
            }

        } else if(transform.position.z < 0){
            Destroy(gameObject);
        }
    }
}
