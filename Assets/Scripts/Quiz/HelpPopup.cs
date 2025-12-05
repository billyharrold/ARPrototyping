using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HelpPopup : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public GameObject helpPanel;

    public Button quizButton;

    public Button leaderboardButton;

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
        quizButton.gameObject.SetActive(false);
        leaderboardButton.gameObject.SetActive(false);
    }

    public void hidePanel()
    {
        helpPanel.SetActive(false);
        quizButton.gameObject.SetActive(true);
        leaderboardButton.gameObject.SetActive(true);

    }


}
