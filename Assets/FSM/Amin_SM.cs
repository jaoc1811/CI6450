using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Amin_SM : MonoBehaviour
{
    List<State> states;

    State initialState;
    public State currentState;

    Transition triggeredTransition;

    public Sprite dormido;

    public Sprite despierto;

    public Sprite drunk;

    public Sprite huyendo;

    public AudioSource audioSource;

    public AudioClip audioClip;

    void Start()
    {
        states = new List<State>();

        // Breaking
        List<Transition> breakingTrans = new List<Transition>();
        breakingTrans.Add(new BreakToBreakTrans(gameObject));
        breakingTrans.Add(new BreakToHideTrans(gameObject));
        BreakingState breaking = new BreakingState(gameObject, breakingTrans);
        states.Add(breaking);

        // Hiding
        List<Transition> hidingTrans = new List<Transition>();
        hidingTrans.Add(new SleepingTrans(gameObject));
        hidingTrans.Add(new CatchTrans(gameObject));
        HidingState hiding = new HidingState(gameObject, hidingTrans);
        states.Add(hiding);

        // Hide
        List<Transition> hideTrans = new List<Transition>();
        hideTrans.Add(new BreakingTrans(gameObject));
        SleepingState sleeping = new SleepingState(gameObject,hideTrans);
        states.Add(sleeping);

        // Puke

        // Faint

        initialState = breaking;
        currentState = breaking;

        triggeredTransition = null;
        gameObject.GetComponent<PathFinding>().target = null;
   
    }

    void Update()
    {

        triggeredTransition = null;
        foreach(Transition transition in currentState.GetTransitions()){
            if (transition.IsTriggered()){
                triggeredTransition = transition;
                triggeredTransition.GetAction();
                break;
            }
        }

        if(triggeredTransition != null){
            string targetState = triggeredTransition.GetTargetState();


            foreach(State state in states){
                if(targetState.Equals(state.name)){
                    currentState = state;
                }
            }
        }


        currentState.GetAction();

    }
}