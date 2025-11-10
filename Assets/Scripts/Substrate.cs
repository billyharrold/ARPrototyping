using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System.Collections.Generic;

public class Substrate : InteractableObjectBase
{
    private Transform ActiveSite;
    public Transform Enzyme;
    public GameObject Enzyme1;

    public float MoveSpeed = 0.3f;
    public float rotationSpeed = 2f;

    private Vector3 originalPosition;
    private Quaternion originalRotation;

    private void Start()
    {
        originalPosition = transform.position;
        originalRotation = transform.rotation;

        if (Enzyme1 != null)
        {
            Transform site_pos = Enzyme1.transform.Find("Merge Location");
            if (site_pos != null)
            {
                ActiveSite = site_pos;
                Debug.Log("Active Site pos found");
            }
            else
            {
                Debug.Log("Active Site not found");
            }
        }
        
    }



    protected override void SetState(State state)
    {
        base.SetState(state);
        switch (state)
        {
            case State.Idle:
                //Debug.Log("IDLE - Subs");
                Debug.Log(hasMerged + "Substrate");
               // hasMerged = false;
                break;
            case State.Active:
                Debug.Log(hasMerged + "Substrate");
                if (hasMerged == true)
                {
                    MoveToEnzyme();
                }
                
                break;
            
        }
    }

    private void MoveToEnzyme()
    {
        if (ActiveSite != null)
        {
            if (hasMerged == true)
            {
                transform.position = Vector3.Lerp(transform.position, ActiveSite.position, Time.deltaTime * MoveSpeed);
                transform.rotation = Quaternion.Lerp(transform.rotation, ActiveSite.rotation, Time.deltaTime * MoveSpeed);
            }
            
        }

    }

    //private void OnTriggerStay(Collider other)
    //{
    //    //MoveToEnzyme();
    //}
}
