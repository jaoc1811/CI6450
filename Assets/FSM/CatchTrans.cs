using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatchTrans : Transition
{
    GameObject character;

    float reachRadius = 1f;

    public CatchTrans(GameObject ch){
        character = ch;
    }

    public override bool IsTriggered(){
        
        if(GameObject.Find("manuelito").GetComponent<PathFinding>().target != null && GameObject.Find("manuelito").GetComponent<Manuelito_SM>().currentState.name == "follow"){
            if(Vector3.Distance(GameObject.Find("manuelito").transform.position, GameObject.Find("manuelito").GetComponent<PathFinding>().target.transform.position) <= reachRadius){
                return true;
            }
        }
        if(GameObject.Find("basanta").GetComponent<PathFinding>().target != null && GameObject.Find("basanta").GetComponent<Basanta_SM>().currentState.name == "follow"){
            if(Vector3.Distance(GameObject.Find("basanta").transform.position, GameObject.Find("basanta").GetComponent<PathFinding>().target.transform.position) <= reachRadius){
                return true;
            }
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
