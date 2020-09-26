using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanceTrans : Transition
{
    GameObject character;

    public DanceTrans(GameObject ch){
        character = ch;
    }

    public override bool IsTriggered(){
        if(GameObject.FindGameObjectsWithTag("vomit").Length == 0){
            return true;
        }
        return false;
    }

    public override void GetAction(){
        return;
    }

    public override string GetTargetState(){
        return "dancing";
    }
}
