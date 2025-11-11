using UnityEngine;

public class SubstrateMove : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public Enzyme enzymeScript;

    public GameObject enzyme;
    public GameObject substrate;
    private Transform activeSite;
    bool merging = false;

    public float moveSpeed = 2f;
    public float rotationSpeed = 2f;

    public float mergeDistance;


    void Start()
    {
        activeSite = enzyme.transform.Find("Active Site");
        if (activeSite == null )
        {
            Debug.LogWarning("No active site found");
        }
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(activeSite.transform.position, enzyme.transform.position);


        if (enzymeScript.collided == true)
        {
            Debug.Log("Function call");
            MoveToEnzyme();
        }

        if (merging)
        {
            transform.position = Vector3.Lerp(transform.position, activeSite.position, Time.deltaTime * moveSpeed);
            transform.rotation = Quaternion.Lerp(transform.rotation, activeSite.rotation, Time.deltaTime * rotationSpeed);
        }

    }


    private void MoveToEnzyme()
    {
        //transform.SetParent(activeSite);
        merging = true;
    }

   

}
