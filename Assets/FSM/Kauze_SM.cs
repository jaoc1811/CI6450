using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kauze_SM : MonoBehaviour
{
    List<State> states;

    State initialState, currentState;

    Transition triggeredTransition;

    public Sprite limpiando;

    public Sprite bailando;

    public Sprite mascara;
    
    // Start is called before the first frame update
    void Start()
    {
        states = new List<State>();

        // Cleaning
        List<Transition> cleanTrans = new List<Transition>();
        cleanTrans.Add(new DanceTrans(gameObject));
        CleaningState cleaning = new CleaningState(gameObject, cleanTrans);
        states.Add(cleaning);

        // Dancing
        List<Transition> danceTrans = new List<Transition>();
        danceTrans.Add(new CleanTrans(gameObject));
        DancingState dancing = new DancingState(gameObject, danceTrans);
        states.Add(dancing);

        initialState = dancing;
        currentState = dancing;

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

            foreach(State state in states){
                if(targetState.Equals(state.name)){
                    currentState = state;

                }
            }
        }
        currentState.GetAction();
    }
}
