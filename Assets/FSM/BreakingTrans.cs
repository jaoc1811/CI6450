using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BreakingTrans : Transition
{

    GameObject character;

    float secureDistance = 6f;

    public BreakingTrans(GameObject ch){
        character = ch;
    }

    public override bool IsTriggered(){

        float manuelito = Vector3.Distance(character.transform.position, GameObject.Find("manuelito").transform.position);
        float basanta = Vector3.Distance(character.transform.position, GameObject.Find("basanta").transform.position);
        return (manuelito > secureDistance) && (basanta > secureDistance);

    }

    public override void GetAction(){
        return;
    }

    public override string GetTargetState(){
        return "breaking";
    }

   
}
