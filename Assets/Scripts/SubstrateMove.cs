using UnityEngine;

public class SubstrateMove : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public Enzyme enzymeScript;

    public GameObject enzyme;
    public GameObject substrate;
    
    private Transform activeSite;
    private Transform spawnPoint;
    
    private bool merging = false;

    public float moveSpeed = 2f;
    public float rotationSpeed = 2f;

    private Renderer rend;


    void Start()
    {

        rend = GetComponent<Renderer>();
        rend.enabled = false;


        spawnPoint = enzyme.transform.Find("Spawn Point");
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

        rend.enabled = merging;

        if (enzymeScript.collided == true)
        {
            Debug.Log("Function call");
            MoveToEnzyme();
        }
        if (enzymeScript.collided == false)
        {
            merging = false;

        }


        if (merging)
        {
            transform.position = Vector3.Lerp(transform.position, activeSite.position, Time.deltaTime * moveSpeed);
            transform.rotation = Quaternion.Lerp(transform.rotation, activeSite.rotation, Time.deltaTime * rotationSpeed);
        }
        if (!merging)
        {
            
            transform.position = spawnPoint.position;
        }

    }


    private void MoveToEnzyme()
    {
        //transform.SetParent(activeSite);
        
        merging = true;
    }

    private void MoveToSpawn()
    {
        transform.position = spawnPoint.position;
        //merging = false;    
    }

   

}
