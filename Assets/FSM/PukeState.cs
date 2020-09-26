using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PukeState : State
{

    PathFinding pathFinding;

    List<Transition> transitions;

    GameObject character;

    float getRadius = 0.5f;

    float timer = Time.time + 5;

    public PukeState(GameObject ch, List<Transition> trans){
        character = ch;
        transitions = trans;
        name="puke";

        pathFinding = character.GetComponent<PathFinding>();
        pathFinding.target = null;
    }

    public override void GetAction(){

        character.GetComponent<SpriteRenderer>().sprite = character.GetComponent<Manuelito_SM>().drunk;
        if(timer <= Time.time){
            character.GetComponent<Shot>().launch = true;
            timer = Time.time + 5;
        } else {
            character.GetComponent<Shot>().launch = false;

        }

        if(GameObject.FindGameObjectsWithTag("beer").Length == 0){
            character.GetComponent<agent>().velocity = Vector3.zero;
            character.GetComponent<agent>().steering.linear = Vector3.zero;
        } else{

            pathFinding.target = nearestBeer(GameObject.FindGameObjectsWithTag("beer"));

            if(Vector3.Distance(character.transform.position, pathFinding.target.transform.position) <= getRadius){
                Object.Destroy(pathFinding.target);
                character.GetComponent<Manuelito_SM>().audioSource.PlayOneShot(character.GetComponent<Manuelito_SM>().audioClip, 1f);
                character.GetComponent<Manuelito_SM>().beers += 1;
            }
        }
    }

    public override List<Transition> GetTransitions(){
        return transitions;
    }
    GameObject nearestBeer(GameObject[] beers){
        GameObject nearest = beers[0];
        float minDistance = Vector3.Distance(character.transform.position,nearest.transform.position);

        foreach(GameObject beer in beers){
            if(Vector3.Distance(beer.transform.position,character.transform.position)<minDistance){
                nearest = beer;
                minDistance = Vector3.Distance(beer.transform.position,character.transform.position);
            }
        }

        return nearest;
    }
}
