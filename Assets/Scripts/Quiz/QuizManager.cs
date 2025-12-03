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

    public Button[] answerButtons;

    public Button quizStart;


    int currentQuestion = 0;
    int score = 0;
    


    void Start()
    {
        deactivateQuiz();
        updateQuestion();
        nextButton.interactable = false;   
    }

    void updateQuestion()
    {
        question.text = questions[currentQuestion].questionText;

        buttons[0].text = questions[currentQuestion].A;
        buttons[1].text = questions[currentQuestion].B;

        
        
    }

    public void checkAnswer(string answer)
    {
        if (answer[0] == questions[currentQuestion].answer)
        {
            
            score += 5;
            buttons[2].text = "Correct" + score.ToString() + "Points gained";
            nextButton.interactable = true;

        }
        else
        {
            buttons[2].text = "Incorrect, try again";
            nextButton.interactable = true;
        }

        
        disableAnswers();
    }

    void disableAnswers()
    {
        foreach (var button in answerButtons)
        {
            button.interactable = false;
        }
    }

    void enableAnswers()
    {
        foreach (var button in answerButtons)
        {
            button.interactable = true;
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
    public void nextClick()
    {
        currentQuestion++;
        enableAnswers(); 
        updateQuestion(); // debug to move on.
        
    }

    public void activateQuiz()
    {
        question.gameObject.SetActive(true);
        nextButton.gameObject.SetActive(true);
        foreach (var button in answerButtons)
        {
            button.gameObject.SetActive(true);
        }
        quizStart.gameObject.SetActive(false);
    }

    public void deactivateQuiz() 
    {
       question.gameObject.SetActive(false);
       nextButton.gameObject.SetActive(false);
       foreach (var button in answerButtons)
        {
            button.gameObject.SetActive(false);
        }
        quizStart.gameObject.SetActive(true);


    }

    public void resetQuiz()
    {

    }

}
