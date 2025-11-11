using UnityEngine;

public class OnTouch : MonoBehaviour
{

    public GameObject enzymePopUp;
    public Transform child;
    //public GameObject enzyme;
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

                if (hit.transform.tag == "Enzyme")
                {
                    Vector3 pos = hit.point;
                    
                    //pos.z += 0.25f;
                    //pos.y += 0.25f;
                    Instantiate(enzymePopUp, child.transform.position, transform.rotation);
                }
            }
        }
    }

    //void getChildPos(GameObject info_spawn)
    //{
    //    info_spawn = enzyme.GetComponentInChildren<GameObject>();
    //}
}
