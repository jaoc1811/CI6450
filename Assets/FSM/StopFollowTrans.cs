using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StopFollowTrans : Transition
{
    float getRadius=0.5f;
    GameObject character;

    public StopFollowTrans(GameObject ch){
        character = ch;
    }

    public override bool IsTriggered(){
        if(GameObject.Find("amin").GetComponent<Amin_SM>().currentState.name == "sleeping"){
            return true;
        } else{
            return false;
        }


    }

    public override void GetAction(){
        foreach(GameObject exclamation in GameObject.FindGameObjectsWithTag("exclamation")){
            UnityEngine.Object.Destroy(exclamation);
        }
        return;
    }

    public override string GetTargetState(){
        return "drinking";
    }

   
}
