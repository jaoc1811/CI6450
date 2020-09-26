using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SleepingState : State
{

    List<Transition> transitions;

    GameObject character;

    public SleepingState(GameObject ch, List<Transition> trans){
        character = ch;
        transitions = trans;
        name="sleeping";  
    }

    public override void GetAction(){

        if(character.name == "basanta"){
            character.GetComponent<SpriteRenderer>().sprite = character.GetComponent<Basanta_SM>().dormido;
        } else if(character.name == "manuelito"){
            character.GetComponent<SpriteRenderer>().sprite = character.GetComponent<Manuelito_SM>().faint;
        } else if(character.name == "amin"){
            character.GetComponent<SpriteRenderer>().sprite = character.GetComponent<Amin_SM>().dormido;
        }
        
        character.GetComponent<agent>().steering.linear = Vector3.zero;
        character.GetComponent<agent>().velocity = Vector3.zero;
    }

    public override List<Transition> GetTransitions(){
        return transitions;
    }
    

}
