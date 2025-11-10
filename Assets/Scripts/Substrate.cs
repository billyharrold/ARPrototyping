using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System.Collections.Generic;

public class Substrate : InteractableObjectBase
{
    private Transform ActiveSite;
    
    public GameObject Enzyme1;

    public float MoveSpeed = 0.3f;
    public float rotationSpeed = 2f;
    public float detectionDistance = 10f;

    public bool inRange = false;
    public bool hasMerged = false;

    private Vector3 originalPosition;
    private Quaternion originalRotation;

    private void Start()
    {
        originalPosition = transform.position;
        originalRotation = transform.rotation;

        if (Enzyme1 != null)
        {
            // Find the merge location on the enzyme and check if it is there.
            Transform site_pos = Enzyme1.transform.Find("Merge Location");
            if (site_pos != null)
            {
                // Set transform of merge location to Active site reference
                ActiveSite = site_pos;
                Debug.Log("Active Site pos found");
            }
            else
            {
                Debug.Log("Active Site not found");
            }
        }
        
    }

    private void Update()
    {
        if (hasMerged == true)
        {
            MoveToEnzyme();
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if its colliding with the right enzyme
        if (other.CompareTag("Enzyme"))
        {
            float distance = Vector3.Distance(transform.position, other.transform.position);
            if (distance < detectionDistance)
            {
                inRange = true;
            }
            
          
           


        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enzyme"))
        {
            float distance = Vector3.Distance(transform.position, other.transform.position);
            if (distance < detectionDistance)
            {
                hasMerged = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        inRange = false;
        hasMerged = false;
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
                
                
                break;
            
        }
    }

    private void MoveToEnzyme()
    {
        if (ActiveSite != null)
        {
            
                transform.position = Vector3.Lerp(transform.position, ActiveSite.position, Time.deltaTime * MoveSpeed);
                transform.rotation = Quaternion.Lerp(transform.rotation, ActiveSite.rotation, Time.deltaTime * MoveSpeed);
            
            
        }

    }

    //private void OnTriggerStay(Collider other)
    //{
    //    //MoveToEnzyme();
    //}
}
