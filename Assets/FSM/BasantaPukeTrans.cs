using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BasantaPukeTrans : Transition
{
    float closeRadius= 4f;
    GameObject character;

    public BasantaPukeTrans(GameObject ch){
        character = ch;
    }

    public override bool IsTriggered(){

        if(GameObject.FindGameObjectWithTag("vomit") != null){
            if(Vector3.Distance(character.transform.position,nearestBeer(GameObject.FindGameObjectsWithTag("vomit")).transform.position) <= closeRadius){
                return true;
            }
        }

        return false;
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

    public override void GetAction(){
        return;
    }

    public override string GetTargetState(){
        return "goingtosleeppuking";
    }

   
}
