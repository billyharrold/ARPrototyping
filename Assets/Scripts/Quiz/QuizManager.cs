using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class QuizManager : MonoBehaviour
{
    

    public List<Question> questions = new List<Question>(); // List of Scriptable Object Questions

    public TMP_Text question;
    public TMP_Text[] buttons;
    public Button nextButton;

    int currentQuestion = 0;
    int score = 0;
    


    void Start()
    {
        updateQuestion();
    }

    void updateQuestion()
    {
        question.text = questions[currentQuestion].questionText;

        buttons[0].text = questions[currentQuestion].A;
        buttons[1].text = questions[currentQuestion].B;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
