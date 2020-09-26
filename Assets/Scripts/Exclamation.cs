using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exclamation : MonoBehaviour
{

    GameObject manuelito;

    GameObject basanta;

    GameObject target;

    public Vector3 offset;
    
    void Awake(){
        basanta = GameObject.Find("basanta");
        manuelito = GameObject.Find("manuelito");

        if(Vector3.Distance(transform.position,basanta.transform.position) < Vector3.Distance(transform.position,manuelito.transform.position)){
            target = basanta;
        } else {
            target = manuelito;
        }

        transform.position = target.transform.position + offset;

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.transform.position + offset;
    }
}
