using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanTrans : Transition
{
    GameObject character;

    public CleanTrans(GameObject ch){
        character =ch;
    }

    public override bool IsTriggered(){
        if(GameObject.FindGameObjectsWithTag("vomit").Length > 0){
            return true;
        }

        return false;
    }

    public override void GetAction(){
        return;
    }

    public override string GetTargetState(){
        return "cleaning";
    }
}
