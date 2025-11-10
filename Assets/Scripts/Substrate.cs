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

    public float seperationDelay = 0.5f;

   
    

    private Vector3 originalPosition;
    private Quaternion originalRotation;

    private float timer = 0f;
    private bool isTransitioning = false;
    public bool hasMerged = false;



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
        if (object_state == State.Active && hasMerged)
        {
            MoveToEnzyme();
        }
        else if (object_state == State.Idle && !hasMerged)
        {
            Debug.Log("Ill get to this part");
        }

        if (isTransitioning)
        {
            timer -= Time.deltaTime;
            if (timer < 0f)
            {
                isTransitioning = false;
                if (object_state == State.Idle)
                {
                    hasMerged = false;
                }
            }
        }
    }

    protected override void SetState(State state)
    {
        base.SetState(state);
        switch (state)
        {
            case State.Active:
                hasMerged = true;
                isTransitioning = false;
                break;
            case State.Idle:
                timer = seperationDelay;
                isTransitioning = true;
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
