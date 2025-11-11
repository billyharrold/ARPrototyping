using UnityEngine;

public class OnTouch : MonoBehaviour
{

    public GameObject enzymePopUp;
    public Transform child;
  
    private GameObject popUp;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (child == null)
        {
            Transform found = transform.Find("Info Point");
            if (found != null)
                child = found;
        }
    }

    // Update is called once per frame
    void Update()
    {
       
        OnClicked();
    }

    void OnClicked()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("CLICKED");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
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
                        Vector3 pos = hit.point;

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
    }

    //void getChildPos(GameObject info_spawn)
    //{
    //    info_spawn = enzyme.GetComponentInChildren<GameObject>();
    //}
}
