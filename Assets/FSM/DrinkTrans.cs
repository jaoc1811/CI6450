using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DrinkTrans : Transition
{
    float delay = 10f;
    DateTime creationTime;
    GameObject character;
    bool changeCreationTime = true;

    public DrinkTrans(GameObject ch){
        character = ch;
    }

    public override bool IsTriggered(){

        if(changeCreationTime){
            creationTime = System.DateTime.Now;
            changeCreationTime = false;
            if(character.name == "basanta"){
                character.GetComponent<Basanta_SM>().beers = 0;
            } else if(character.name == "manuelito"){
                character.GetComponent<Manuelito_SM>().beers = 0;
            }
        }
        DateTime currentTime = System.DateTime.Now;
        if(Mathf.Abs((float)((currentTime - creationTime).TotalSeconds))> delay){
            return true;
        }
        return false;
    }

    public override void GetAction(){
        return;
    }

    public override string GetTargetState(){
        changeCreationTime = true;
        return "drinking";
    }

   
}
