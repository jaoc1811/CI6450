using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Transition{

    public abstract bool IsTriggered();

    public abstract void GetAction();

    public abstract string GetTargetState();

}