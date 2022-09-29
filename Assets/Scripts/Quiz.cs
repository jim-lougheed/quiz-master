using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [Header("Questions")]
    QuestionSO currentQuestion;
    [SerializeField] List<QuestionSO> questions = new List<QuestionSO>();
    [SerializeField] TextMeshProUGUI questionText;

    [Header("Responses")]
    [SerializeField] GameObject[] responseButtons;
    int answerIndex;
    bool hasRespondedEarly;

    [Header("Button Colours")]
    [SerializeField] Sprite defaultResponseSprite;
    [SerializeField] Sprite answerSprite;

    [Header("Timer")]
    [SerializeField] Image timerImage;
    Timer timer;

    void Start()
    {
        timer = FindObjectOfType<Timer>();
    }

    void Update() {
        timerImage.fillAmount = timer.fillFraction;
        if (timer.loadNextQuestion) {
            hasRespondedEarly = false;
            GetNextQuestion();
            timer.loadNextQuestion = false;
        } else if (!hasRespondedEarly && !timer.questionActive) {
            DisplayAnswer(-1);
            SetButtonState(false);
        }
    }

    void DisplayQuestion() {
        questionText.text = currentQuestion.GetQuestion();
        
        for (int i = 0; i < responseButtons.Length; i++) {
            TextMeshProUGUI buttonText = responseButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = currentQuestion.GetResponse(i);
        }
    }

    public void OnResponseSelected(int index) {
        hasRespondedEarly = true;
        DisplayAnswer(index);
        SetButtonState(false);
        timer.CancelTimer();
    }

    void DisplayAnswer(int index) {
        Image buttonImage;
        if (index == currentQuestion.GetAnswerIndex()) {
            questionText.text = "Correct!";
            buttonImage = responseButtons[index].GetComponent<Image>();
            buttonImage.sprite = answerSprite;
        } else {
            answerIndex = currentQuestion.GetAnswerIndex();
            string answer = currentQuestion.GetResponse(answerIndex);
            questionText.text = "Wrong..." + answer;
            buttonImage = responseButtons[answerIndex].GetComponent<Image>();
            buttonImage.sprite = answerSprite;
        }
    }

    void SetButtonState(bool state) {
        for (int i = 0; i < responseButtons.Length; i++) {
            responseButtons[i].GetComponent<Button>().interactable = state;
        }
    }

    void SetDefaultButtonSprite() {
        for (int i = 0; i < responseButtons.Length; i++) {
            responseButtons[i].GetComponent<Image>().sprite = defaultResponseSprite;
        }
    }

    void GetNextQuestion() {
        if (questions.Count > 0) {
            SetButtonState(true);
            SetDefaultButtonSprite();
            GetRandomQuestion();
            DisplayQuestion();
        }
    }

    void GetRandomQuestion() {
        int index = Random.Range(0, questions.Count);
        currentQuestion = questions[index];
        if (questions.Contains(currentQuestion)) {
            questions.Remove(currentQuestion);
        }
    }
}
