using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoingToSleepTrans : Transition
{

    GameObject character;

    public GoingToSleepTrans(GameObject ch){
        character = ch;
    }

    public override bool IsTriggered(){
        if(character.GetComponent<Basanta_SM>().beers == 4){
            return true;
        }
        return false;
    }

    public override void GetAction(){
        return;
    }

    public override string GetTargetState(){
        character.GetComponent<PathFinding>().target = null;
        return "goingtosleep";
    }
}
