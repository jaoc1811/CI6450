using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manuelito_SM : MonoBehaviour
{
    List<State> states;

    State initialState;
    public State currentState;

    Transition triggeredTransition;

    public GameObject exclamation;

    public int beers = 0;

    public Sprite despierto;

    public Sprite drunk;

    public Sprite faint;

    public Sprite molesto;


    public AudioSource audioSource;

    public AudioClip audioClip;

    // Start is called before the first frame update
    void Start()
    {
        states = new List<State>();

        // Drinking
        List<Transition> drinkingTrans = new List<Transition>();
        drinkingTrans.Add(new PukeTrans(gameObject));
        drinkingTrans.Add(new FollowTrans(gameObject));
        DrinkingState drinking = new DrinkingState(gameObject, drinkingTrans);
        states.Add(drinking);

        // Puke
        List<Transition> pukeTrans = new List<Transition>();
        pukeTrans.Add(new FaintTrans(gameObject));
        PukeState puke = new PukeState(gameObject,pukeTrans);
        states.Add(puke);

        // Faint
        List<Transition> faintTrans = new List<Transition>();
        faintTrans.Add(new DrinkTrans(gameObject));
        SleepingState faint = new SleepingState(gameObject,faintTrans);
        states.Add(faint);

        // Following
        List<Transition> followingTrans = new List<Transition>();
        followingTrans.Add(new StopFollowTrans(gameObject));
        FollowState following = new FollowState(gameObject,followingTrans);
        states.Add(following);

        initialState = drinking;
        currentState = drinking;

        triggeredTransition = null;
        gameObject.GetComponent<PathFinding>().target=null;
    }

    // Update is called once per frame
    void Update()
    {
        triggeredTransition = null;
        foreach(Transition transition in currentState.GetTransitions()){
            if (transition.IsTriggered()){
                triggeredTransition = transition;
                break;
            }
        }

        if(triggeredTransition != null){
            string targetState = triggeredTransition.GetTargetState();

            triggeredTransition.GetAction();

            foreach(State state in states){
                if(targetState.Equals(state.name)){
                    currentState = state;

                }
            }
        }
        currentState.GetAction();
    }
}
