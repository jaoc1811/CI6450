using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleaningState : State
{
    PathFinding pathFinding;

    float closeRadius= 4f;
    float getRadius=0.5f;

    List<Transition> transitions;

    GameObject character;

    public CleaningState(GameObject ch, List<Transition> trans){
        character= ch;
        transitions = trans;
        name = "cleaning";

        pathFinding = character.GetComponent<PathFinding>();
        pathFinding.target = null;
    }

    public override void GetAction(){
        character.GetComponent<LookWhereYoureGoing>().enabled = true;
        character.GetComponent<SpriteRenderer>().sprite = character.GetComponent<Kauze_SM>().limpiando;
        pathFinding.target = nearestPuke(GameObject.FindGameObjectsWithTag("vomit"));

        if(Vector3.Distance(character.transform.position, pathFinding.target.transform.position) <= closeRadius){
            character.GetComponent<SpriteRenderer>().sprite = character.GetComponent<Kauze_SM>().mascara;
        } else {
            character.GetComponent<SpriteRenderer>().sprite = character.GetComponent<Kauze_SM>().limpiando;
        }
        if(Vector3.Distance(character.transform.position, pathFinding.target.transform.position) <= getRadius){
            Object.Destroy(pathFinding.target);
        }
    }

    GameObject nearestPuke(GameObject[] pukes){

        GameObject nearest = pukes[0];

        float minDistance = Vector3.Distance(character.transform.position,nearest.transform.position);

        foreach(GameObject puke in pukes){
            if(Vector3.Distance(puke.transform.position,character.transform.position)<minDistance && puke.transform.position.z == 0){
                nearest = puke;
                minDistance = Vector3.Distance(puke.transform.position,character.transform.position);
            }
        }

        return nearest;
    }

    public override List<Transition> GetTransitions(){
        return transitions;
    }
}
