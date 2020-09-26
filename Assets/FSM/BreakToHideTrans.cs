using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BreakToHideTrans : Transition
{
    DateTime creationTime;
    float getRadius=1f;

    float hearRadius = 5f;
    GameObject character;

    public BreakToHideTrans(GameObject ch){
        character = ch;
    }

    public override bool IsTriggered(){
        bool breakbeer = false;
        if(character.GetComponent<PathFinding>().target != null){
            breakbeer = Vector3.Distance(character.transform.position, character.GetComponent<PathFinding>().target.transform.position) <= getRadius;
        }
        bool manuelito = Vector3.Distance(character.transform.position, GameObject.Find("manuelito").transform.position) <= hearRadius;
        bool basanta = Vector3.Distance(character.transform.position, GameObject.Find("basanta").transform.position) <= hearRadius;
        return (breakbeer && manuelito && GameObject.Find("manuelito").GetComponent<Manuelito_SM>().currentState.name == "drinking") || (breakbeer && basanta && GameObject.Find("basanta").GetComponent<Basanta_SM>().currentState.name == "drinking");
    }

    public override void GetAction(){
        character.GetComponent<Amin_SM>().audioSource.PlayOneShot(character.GetComponent<Amin_SM>().audioClip, 1f);
        UnityEngine.Object.Destroy(character.GetComponent<PathFinding>().target);
        return;
    }

    public override string GetTargetState(){
        return "hiding";
    }

   
}
