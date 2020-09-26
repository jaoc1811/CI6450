using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidingState : State{

    PathFinding pathFinding;

    float getRadius=0.5f;

    List<Transition> transitions;

    GameObject character;

    public HidingState(GameObject ch, List<Transition> trans){
        character = ch;
        transitions = trans;
        name="hiding";

        pathFinding = character.GetComponent<PathFinding>();
        pathFinding.target = null;
    }
    public override void GetAction(){

        character.GetComponent<SpriteRenderer>().sprite = character.GetComponent<Amin_SM>().huyendo;

        GameObject[] hidingSpots = GameObject.FindGameObjectsWithTag("amin");

        pathFinding.target = nearestHidingSpot(hidingSpots);

    }

    GameObject nearestHidingSpot(GameObject[] hidingSpots){
        GameObject nearest = hidingSpots[0];
        float minDistance = Vector3.Distance(character.transform.position,nearest.transform.position);

        foreach(GameObject hidingSpot in hidingSpots){
            if(Vector3.Distance(hidingSpot.transform.position,character.transform.position)<minDistance){
                nearest = hidingSpot;
                minDistance = Vector3.Distance(hidingSpot.transform.position,character.transform.position);
            }
        }

        return nearest;
    }


    public override List<Transition> GetTransitions(){
        return transitions;
    }
}

