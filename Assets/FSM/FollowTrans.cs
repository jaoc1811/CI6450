using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FollowTrans : Transition
{
    float getRadius=0.5f;
    float hearRadius = 5f;
    GameObject character;

    public FollowTrans(GameObject ch){
        character = ch;
    }

    public override bool IsTriggered(){
        bool amin = Vector3.Distance(character.transform.position, GameObject.Find("amin").transform.position) <= hearRadius;
        return (GameObject.Find("amin").GetComponent<Amin_SM>().currentState.name == "hiding" && amin);
    }

    public override void GetAction(){
        if(character.name == "basanta"){
            GameObject.Find("basanta").GetComponent<Basanta_SM>().exclamation.transform.position = character.transform.position;
            UnityEngine.Object.Instantiate(GameObject.Find("basanta").GetComponent<Basanta_SM>().exclamation);
        } else if (character.name == "manuelito"){
            GameObject.Find("manuelito").GetComponent<Manuelito_SM>().exclamation.transform.position = character.transform.position;
            UnityEngine.Object.Instantiate(GameObject.Find("manuelito").GetComponent<Manuelito_SM>().exclamation);
        }
        return;
    }

    public override string GetTargetState(){
        return "follow";
    }

   
}
