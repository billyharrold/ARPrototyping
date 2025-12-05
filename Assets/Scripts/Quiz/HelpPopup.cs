using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HelpPopup : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public GameObject helpPanel;

    void Start()
    {
        hidePanel();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showPanel()
    {
        helpPanel.SetActive(true);
    }

    public void hidePanel()
    {
        helpPanel.SetActive(false);
    }


}
