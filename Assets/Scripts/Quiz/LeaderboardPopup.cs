using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LeaderboardPopup : MonoBehaviour
{
    // Start is called once before the first
    // execution of Update after the MonoBehaviour is created


    public GameObject panel;

    public Button quizButton;

    public Button infoButton;

    


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
        panel.SetActive(true);
        quizButton.gameObject.SetActive(false);
        infoButton.gameObject.SetActive(false);
    }

    public void hidePanel()
    {
        panel.SetActive(false);
        quizButton.gameObject.SetActive(true);
        infoButton.gameObject.SetActive(true);
    }
}
