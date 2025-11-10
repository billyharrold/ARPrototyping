using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System.Collections.Generic; 

public abstract class InteractableObjectBase : MonoBehaviour
{

    private List<InteractableObjectBase> _interactables = new List<InteractableObjectBase>();
    

    protected enum State
    {
        Idle,
        Active
    }
    protected State object_state = State.Idle;

    private float idleDelay = 0.3f;
    private float idleTimer = 0f;

    private void Update()
    {
        // countdown timer for idle transition
        if (_interactables.Count == 0 && object_state == State.Active)
        {
            idleTimer -= Time.deltaTime;
            if (idleTimer <= 0f)
            {
                SetState(State.Idle);
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<InteractableObjectBase>(out var interactable))
        {
            
            AddInteractable(interactable);
        }
    }
    

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<InteractableObjectBase>(out var interactable))
        {
            
            RemoveInteractable(interactable);
        }

    }

    protected void AddInteractable(InteractableObjectBase interactable)
    {
        if (_interactables.Contains(interactable))
        {
            _interactables.Add(interactable);
            SetState(State.Active);
        }
       


        idleTimer = idleDelay;
    }

    protected void RemoveInteractable(InteractableObjectBase interactable)
    {
        if (_interactables.Contains(interactable))
        {
            _interactables.Remove(interactable);
        }
        
        if (_interactables.Count == 0 )
        {
            idleTimer = idleDelay;
        }
    }

    private void OnDisable()
    {
        foreach (var interactable in _interactables)
        {
            interactable.RemoveInteractable(this);

        }
        _interactables.Clear();
        SetState(State.Idle);
    }

    protected virtual void SetState(State state)
    {
        object_state = state;
    }



}
