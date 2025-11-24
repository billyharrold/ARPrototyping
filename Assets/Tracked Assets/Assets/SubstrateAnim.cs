using UnityEngine;

public class SubstrateAnim : MonoBehaviour
{

    private Animator animator;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        if (animator == null )
        {
            Debug.Log("no animator foind");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
