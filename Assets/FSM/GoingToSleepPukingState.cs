using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoingToSleepPukingState : State
{
    PathFinding pathFinding;

    List<Transition> transitions;

    GameObject character;

    float timer = Time.time + 5;


    public GoingToSleepPukingState(GameObject ch, List<Transition> trans){
        character = ch;
        transitions = trans;
        name="goingtosleeppuking";

        pathFinding = character.GetComponent<PathFinding>();
        pathFinding.target = null;
    }
    public override void GetAction(){
        character.GetComponent<SpriteRenderer>().sprite = character.GetComponent<Basanta_SM>().drunk;
        pathFinding.target = GameObject.Find("cama");

        if(timer <= Time.time){
            character.GetComponent<Shot>().launch = true;
            timer = Time.time + 5;
        } else {
            character.GetComponent<Shot>().launch = false;
        }
    }

    public override List<Transition> GetTransitions(){
        return transitions;
    }
}
