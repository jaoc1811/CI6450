using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class keyboardMovement : MonoBehaviour
{   
    public agent character;
    public float speed;
    private Vector3 movement;

    // Update is called once per frame
    void Update()
    {   
        movement = Vector3.zero;

        if(Input.GetAxisRaw ("Vertical") > 0)
		{
			movement += new Vector3 (0 , 1, 0);

		}if(Input.GetAxisRaw ("Vertical") < 0)
		{
			movement += new Vector3 (0, 0 -1, 0);

		}if(Input.GetAxisRaw ("Horizontal") > 0)
		{
			movement += new Vector3 (0 + 1, 0, 0);
		}if(Input.GetAxisRaw ("Horizontal") < 0)
		{
			movement += new Vector3 (0 - 1, 0, 0);
        }

        movement.Normalize();
        
        character.velocity = movement * speed;
        // transform.position += movement * speed * Time.deltaTime;
        transform.rotation = character.newOrientation(transform.rotation,movement);
    }
}
