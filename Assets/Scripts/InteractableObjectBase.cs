using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System.Collections.Generic; 

public abstract class InteractableObjectBase : MonoBehaviour
{

    private List<InteractableObjectBase> _interactables = new List<InteractableObjectBase>();
    public bool hasMerged;

    protected enum State
    {
        Idle,
        Active
    }
    protected State object_state = State.Idle;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<InteractableObjectBase>(out var interactable))
        {
            hasMerged = true;
            AddInteractable(interactable);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<InteractableObjectBase>(out var interactable))
        {
            hasMerged = false;
            RemoveInteractable(interactable);
        }

    }

    protected void AddInteractable(InteractableObjectBase interactable)
    {
        _interactables.Add(interactable);
        SetState(State.Active);
    }

    protected void RemoveInteractable(InteractableObjectBase interactable)
    {
        _interactables.Remove(interactable);
        if (_interactables.Count == 0 )
        {
            SetState(State.Idle);
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
