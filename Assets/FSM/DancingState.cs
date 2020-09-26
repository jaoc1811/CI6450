using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DancingState : State
{
    GameObject character;

    List<Transition> transitions;

    public DancingState(GameObject ch, List<Transition> trans){
        character =ch;
        transitions =trans;
        name = "dancing";
    }

    public override void GetAction(){

        character.GetComponent<SpriteRenderer>().sprite = character.GetComponent<Kauze_SM>().bailando;
        character.GetComponent<LookWhereYoureGoing>().enabled = false;
        character.GetComponent<agent>().velocity = Vector3.zero;
        character.GetComponent<agent>().steering.linear = Vector3.zero;
        character.GetComponent<agent>().rotation = 10;

    }

    public override List<Transition> GetTransitions(){
        return transitions;
    }
}
