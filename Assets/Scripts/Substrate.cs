using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Serialization;

public class Substrate : InteractableObjectBase
{
    private Transform ActiveSite;
    
    public GameObject Enzyme1;

    public float MoveSpeed = 0.3f;
    public float rotationSpeed = 2f;

    public float detectionDistance = 0.05f;

   
    

    private Vector3 originalPosition;
    private Quaternion originalRotation;

    
    public bool hasMerged = false;
    private float unmergeTimer = 0f;
    public float unmergeDelay = 0.3f;




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
        float distance = Vector3.Distance(transform.position, Enzyme1.transform.position);

        // Check if within merge range
        if (distance < detectionDistance)
        {
            hasMerged = true;
            unmergeTimer = 0f; // cancel unmerge countdown
        }
        else
        {
            if (hasMerged)
            {
                // Start unmerge countdown
                unmergeTimer += Time.deltaTime;
                if (unmergeTimer >= unmergeDelay)
                {
                    hasMerged = false;
                    unmergeTimer = 0f;
                }
            }
        }

        // Move if merged
        if (hasMerged)
        {
            transform.position = Vector3.Lerp(transform.position, ActiveSite.position, Time.deltaTime * MoveSpeed);
            transform.rotation = Quaternion.Lerp(transform.rotation, ActiveSite.rotation, Time.deltaTime * rotationSpeed);
        }
       
    }

    protected override void SetState(State state)
    {
        base.SetState(state);
        switch (state)
        {
            case State.Active:
                hasMerged = true;
               
                
                break;
            case State.Idle:
                hasMerged = false;
                break;
        }

    }









    private void MoveToEnzyme()
    {
       
        Transform current_pos = Enzyme1.transform.Find("Merge Location");

        transform.position = Vector3.Lerp(transform.position, current_pos.position, Time.deltaTime * MoveSpeed);
         transform.rotation = Quaternion.Lerp(transform.rotation, ActiveSite.rotation, Time.deltaTime * MoveSpeed);
            
            
        

    }

    //private void OnTriggerStay(Collider other)
    //{
    //    //MoveToEnzyme();
    //}
}
