using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoingToSleepState : State
{
    PathFinding pathFinding;

    List<Transition> transitions;

    GameObject character;

    public GoingToSleepState(GameObject ch, List<Transition> trans){
        character = ch;
        transitions = trans;
        name="goingtosleep";

        pathFinding = character.GetComponent<PathFinding>();
        pathFinding.target = null;
    }
    public override void GetAction(){
        character.GetComponent<SpriteRenderer>().sprite = character.GetComponent<Basanta_SM>().drunk;
        pathFinding.target = GameObject.Find("cama");
    }

    public override List<Transition> GetTransitions(){
        return transitions;
    }
}
