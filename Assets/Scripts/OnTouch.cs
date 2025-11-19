using UnityEngine;
using UnityEngine.InputSystem;


public class OnTouch : MonoBehaviour
{

    public GameObject enzymePopUp;
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
            OnClicked(screenpos);
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
            Transform found = transform.Find("Info Point");
            if (found != null)
                child = found;
        }
    }




    private void Update()
    {


        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector2 mousePos = Mouse.current.position.ReadValue();
            OnClicked(mousePos);
        }
         
        
    }



    void OnClicked(Vector2 screenpos)
    {
        
            //Debug.Log("CLICKED");
            Ray ray = Camera.main.ScreenPointToRay(screenpos);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                Debug.Log("hit");
                Debug.Log(hit.transform.name + " : " + hit.transform.tag);
                
                
                // Checking hit on Enzyme
                if (hit.transform.CompareTag("Enzyme"))
                {
                    if (popUp == null)
                    {
                       

                        Quaternion rot = Quaternion.Euler(0f, 0f, 0f);


                        //pos.z += 0.25f;
                        //pos.y += 0.25f;
                        popUp = Instantiate(enzymePopUp, child.transform.position, rot, child);
                    }
                    else
                    {
                        Destroy(popUp);
                        popUp = null;
                        Debug.Log("Pop up removed");
                    }
                    
                }

                //// Checking Hit on Substrate
                //if (hit.transform.CompareTag("Substrate"))
                //{
                //    if (popUp == null)
                //    {
                //        Vector3 pos = hit.point;

                //        Quaternion rot = Quaternion.Euler(0f, 0f, 0f);


                //        //pos.z += 0.25f;
                //        //pos.y += 0.25f;
                //        popUp = Instantiate(enzymePopUp, child.transform.position, rot, child);
                //    }
                //    else
                //    {
                //        Destroy(popUp);
                //        popUp = null;
                //        Debug.Log("Pop up removed");
                //    }

                //}

            }
        
    }

    //void getChildPos(GameObject info_spawn)
    //{
    //    info_spawn = enzyme.GetComponentInChildren<GameObject>();
    //}
}
