using UnityEngine;
using UnityEngine.InputSystem;

public class OnTouchSubs : MonoBehaviour
{

    public GameObject substratePopUp;
    public Transform child;

    private GameObject popUp;
    private InputSystem_Actions controls;
    private Vector2 screenpos;




    void Awake()
    {
        controls = new InputSystem_Actions();
    }



    void OnEnable()
    {
        controls.Enable();

        controls.Touch.Position.performed += ctx =>
        {
            screenpos = ctx.ReadValue<Vector2>();
        };

        controls.Touch.Tap.performed += ctx =>
        {
            OnClicked(screenpos);
        };

    }

    void OnDisable()
    {
        controls.Disable();
    }







    void Start()
    {
        if (child == null)
        {
            Transform found = transform.Find("Spawn Point");
            if (found != null)
                child = found;
        }
    }

    // Update is called once per frame
    //void Update()
    //{
    //    OnClicked();
    //}


    private void OnClicked(Vector2 screenpos)
    {
        
            //Debug.Log("CLICKED");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                Debug.Log("hit");
                Debug.Log(hit.transform.name + " : " + hit.transform.tag);




                if (hit.transform.CompareTag("Substrate"))
                {
                    if (popUp == null)
                    {
                        Vector3 pos = hit.point;

                        Quaternion rot = Quaternion.Euler(0f, 0f, 0f);


                        //pos.z += 0.25f;
                        //pos.y += 0.25f;
                        popUp = Instantiate(substratePopUp, child.transform.position, rot, child);
                    }
                    else
                    {
                        Destroy(popUp);
                        popUp = null;
                        Debug.Log("Pop up removed");
                    }

                }
            }
        

    }
}
