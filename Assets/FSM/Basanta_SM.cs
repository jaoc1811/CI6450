using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basanta_SM : MonoBehaviour
{

    List<State> states;

    State initialState;
    public State currentState;

    public GameObject exclamation;

    Transition triggeredTransition;

    public int beers = 0;

    public Sprite dormido;

    public Sprite despierto;

    public Sprite drunk;

    public Sprite molesto;

    public AudioSource audioSource;

    public AudioClip audioClip;



    // Start is called before the first frame update
    void Start()
    {   
        states = new List<State>();

        // Drinking
        List<Transition> drinkingTrans = new List<Transition>();
        drinkingTrans.Add(new GoingToSleepTrans(gameObject));
        drinkingTrans.Add(new FollowTrans(gameObject));
        drinkingTrans.Add(new BasantaPukeTrans(gameObject));
        DrinkingState drinking = new DrinkingState(gameObject, drinkingTrans);
        states.Add(drinking);

        // Going to Sleep
        List<Transition> goingtoTrans = new List<Transition>();
        goingtoTrans.Add(new SleepingTrans(gameObject));
        GoingToSleepState goingto = new GoingToSleepState(gameObject,goingtoTrans);
        states.Add(goingto);

        // Sleeping
        List<Transition> sleepingTrans = new List<Transition>();
        sleepingTrans.Add(new DrinkTrans(gameObject));
        SleepingState sleeping = new SleepingState(gameObject,sleepingTrans);
        states.Add(sleeping);

        // Following
        List<Transition> followingTrans = new List<Transition>();
        followingTrans.Add(new StopFollowTrans(gameObject));
        FollowState following = new FollowState(gameObject,followingTrans);
        states.Add(following);

        // Going to Sleep Puking
        List<Transition> pukingTrans = new List<Transition>();
        pukingTrans.Add(new SleepingTrans(gameObject));
        GoingToSleepPukingState pukingState = new GoingToSleepPukingState(gameObject,pukingTrans);
        states.Add(pukingState);

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
