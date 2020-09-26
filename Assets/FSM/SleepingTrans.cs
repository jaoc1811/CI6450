using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepingTrans : Transition
{
    GameObject character;

    float reachRadius = 0.5f;

    public SleepingTrans(GameObject ch){
        character = ch;
    }

    public override bool IsTriggered(){
        

        if(character.GetComponent<PathFinding>().target != null){
            if(Vector3.Distance(character.transform.position, character.GetComponent<PathFinding>().target.transform.position) < reachRadius){
                return true;
            }
        }
        return false;
    }

    public override void GetAction(){
        character.GetComponent<Shot>().launch = false;
        return;
    }

    public override string GetTargetState(){
        character.GetComponent<PathFinding>().target = null;
        return "sleeping";
    }
}
