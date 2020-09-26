using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkingState : State{

    PathFinding pathFinding;

    float getRadius=0.5f;

    List<Transition> transitions;

    GameObject character;

    public DrinkingState(GameObject ch, List<Transition> trans){
        character = ch;
        transitions = trans;
        name="drinking";

        pathFinding = character.GetComponent<PathFinding>();
        pathFinding.target = null;
    }
    public override void GetAction(){

        if(character.name == "manuelito"){
            character.GetComponent<SpriteRenderer>().sprite = character.GetComponent<Manuelito_SM>().despierto;
            character.GetComponent<agent>().maxSpeed = 2f;
        } else if(character.name == "basanta"){
            character.GetComponent<SpriteRenderer>().sprite = character.GetComponent<Basanta_SM>().despierto;
            character.GetComponent<agent>().maxSpeed = 2f;
        }

        if(GameObject.FindGameObjectsWithTag("beer").Length == 0){
            character.GetComponent<agent>().velocity = Vector3.zero;
            character.GetComponent<agent>().steering.linear = Vector3.zero;

        } else{
            
            pathFinding.target = nearestBeer(GameObject.FindGameObjectsWithTag("beer"));

            if(Vector3.Distance(character.transform.position, pathFinding.target.transform.position) <= getRadius){
                Object.Destroy(pathFinding.target);
                if(character.name == "manuelito"){
                    character.GetComponent<Manuelito_SM>().beers += 1;
                    character.GetComponent<Manuelito_SM>().audioSource.PlayOneShot(character.GetComponent<Manuelito_SM>().audioClip, 1f);
                } else if(character.name == "basanta"){
                    character.GetComponent<Basanta_SM>().beers += 1;
                    character.GetComponent<Basanta_SM>().audioSource.PlayOneShot(character.GetComponent<Basanta_SM>().audioClip, 1f);
                }
            }
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
