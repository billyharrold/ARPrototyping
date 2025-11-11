using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System.Collections.Generic;

public class Enzyme : InteractableObjectBase
{
    public bool collided;

    protected override void SetState(State state)
    {
        base.SetState(state);
        switch (state)
        {
            case State.Idle:
                Debug.Log("IDLE-Enz");
                break;
            case State.Active:
                Debug.Log(state.ToString() + "Enzyme");
                break;

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        collided = true;
        Debug.Log("collided");
    }


}
