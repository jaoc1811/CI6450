using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaintTrans : Transition
{
    GameObject character;

    public FaintTrans(GameObject ch){
        character = ch;
    }

    public override bool IsTriggered(){
        if(character.GetComponent<Manuelito_SM>().beers == 6){
            return true;
        }
        return false;
    }

    public override void GetAction(){
        return;
    }
    
    public override string GetTargetState(){
        character.GetComponent<PathFinding>().target = null;
        return "sleeping";
    }
}
