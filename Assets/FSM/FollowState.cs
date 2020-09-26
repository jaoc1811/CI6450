using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowState : State{

    PathFinding pathFinding;

    float getRadius=0.5f;

    List<Transition> transitions;

    GameObject character;

    public FollowState(GameObject ch, List<Transition> trans){
        character = ch;
        transitions = trans;
        name="follow";

        pathFinding = character.GetComponent<PathFinding>();
        pathFinding.target = null;
    }
    public override void GetAction(){

        if(character.name == "manuelito"){
            character.GetComponent<SpriteRenderer>().sprite = character.GetComponent<Manuelito_SM>().molesto;
            character.GetComponent<agent>().maxSpeed = 2.5f;
        } else if (character.name == "basanta"){
            character.GetComponent<SpriteRenderer>().sprite = character.GetComponent<Basanta_SM>().molesto;
            character.GetComponent<agent>().maxSpeed = 2.5f;

        }

        pathFinding.target = GameObject.Find("amin");
    }

    public override List<Transition> GetTransitions(){
        return transitions;
    }
}

