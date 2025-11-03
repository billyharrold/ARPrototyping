using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System.Collections.Generic;

public class Substrate : InteractableObjectBase
{
    
    protected override void SetState(State state)
    {
        base.SetState(state);
        switch (state)
        {
            case State.Idle:
                Debug.Log("IDLE - Subs");
                break;
            case State.Active:
                break;
            
        }
    }


}
