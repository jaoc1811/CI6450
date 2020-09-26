using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakingState : State{

    PathFinding pathFinding;

    List<Transition> transitions;

    GameObject character;

    float timer = Time.time + 5;

    float closeRadius= 4f;

    public BreakingState(GameObject ch, List<Transition> trans){
        character = ch;
        transitions = trans;
        name="breaking";

        pathFinding = character.GetComponent<PathFinding>();
        pathFinding.target = null;
    }
    public override void GetAction(){

        if(GameObject.FindGameObjectWithTag("vomit") != null){
            if(Vector3.Distance(character.transform.position,nearestBeer(GameObject.FindGameObjectsWithTag("vomit")).transform.position) < closeRadius){
                character.GetComponent<SpriteRenderer>().sprite = character.GetComponent<Amin_SM>().drunk;
                if(timer <= Time.time){
                    character.GetComponent<Shot>().launch = true;
                    timer = Time.time + 5;
                } else {
                    character.GetComponent<Shot>().launch = false;
                }
            } else{
                character.GetComponent<SpriteRenderer>().sprite = character.GetComponent<Amin_SM>().despierto;
            }

        } else {
            character.GetComponent<SpriteRenderer>().sprite = character.GetComponent<Amin_SM>().despierto;
        }
        
        if(GameObject.FindGameObjectsWithTag("beer").Length == 0){
            character.GetComponent<agent>().velocity = Vector3.zero;
            character.GetComponent<agent>().steering.linear = Vector3.zero;

        } else{
            
            pathFinding.target = nearestBeer(GameObject.FindGameObjectsWithTag("beer"));

        }
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


    public override List<Transition> GetTransitions(){
        return transitions;
    }
}
