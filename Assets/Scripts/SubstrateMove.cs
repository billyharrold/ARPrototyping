using UnityEngine;

public class SubstrateMove : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public Enzyme enzymeScript;

    public GameObject enzyme;
    public GameObject substrate;
    
    private Transform activeSite;
    private Transform spawnPoint;


    public GameObject LSubstrate;
    public GameObject RSubstrate;

    private Transform p1;
    private Transform p2;

    private Transform b1;
    private Transform b2;
    
    private bool merging = false;
    private bool audioPlay = false;

    public float moveSpeed = 2f;
    public float rotationSpeed = 2f;

    private Renderer rend;
    private Renderer Lrend;
    private Renderer Rrend;

    public AudioClip movingTo;
    public AudioClip reactionClip;

    AudioSource audioSource;

    //private bool arrived = false;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {

        rend = GetComponent<Renderer>();
        rend.enabled = false;

        Lrend = LSubstrate.GetComponent<Renderer>();
        Lrend.enabled = false;

        Rrend = RSubstrate.GetComponent<Renderer>();
        Rrend.enabled = false;

        spawnPoint = enzyme.transform.Find("Spawn Point");
        activeSite = enzyme.transform.Find("Active Site");

        p1 = enzyme.transform.Find("P1");
        p2 = enzyme.transform.Find("P2");

        b1 = enzyme.transform.Find("B1");
        b2 = enzyme.transform.Find("B2");

        LSubstrate.transform.position = b1.position;
        RSubstrate.transform.position = b2.position;

        if (activeSite == null )
        {
            Debug.LogWarning("No active site found");
        }
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(activeSite.transform.position, transform.position);

        //rend.enabled = merging;

       


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
            //arrived = true;

           
            
        }
        if (!merging)
        {
            
            transform.position = spawnPoint.position;

            ResetReaction();
            audioPlay = false;
            //arrived = false;
        }

        if (distance < 0.01f)
        {
            
            React();
            rend.enabled = false;
            if (!audioPlay)
            {
                audioSource.PlayOneShot(reactionClip);
                audioPlay = true;
            }



        }

    }


    private void MoveToEnzyme()
    {
        //transform.SetParent(activeSite);
        //audioSource.PlayOneShot(movingTo);
        rend.enabled = true;
        merging = true;
    }

    private void MoveToSpawn()
    {
        transform.position = spawnPoint.position;
        //merging = false;    
    }

    private void React()
    {
        
        LSubstrate.transform.position = Vector3.Lerp(LSubstrate.transform.position, p1.position, Time.deltaTime * moveSpeed);
        RSubstrate.transform.position = Vector3.Lerp(RSubstrate.transform.position, p2.position, Time.deltaTime * moveSpeed);
        Lrend.enabled = true;
        Rrend.enabled = true;
        
    }

    private void ResetReaction()
    {
        LSubstrate.transform.position = b1.position;
        RSubstrate.transform.position= b2.position;
        Lrend.enabled = false;
        Rrend.enabled = false;
       
    }

}
