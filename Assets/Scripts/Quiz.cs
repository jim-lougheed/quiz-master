using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [SerializeField] QuestionSO question;
    [SerializeField] TextMeshProUGUI questionText;
    [SerializeField] GameObject[] responseButtons;
    int answerIndex;
    [SerializeField] Sprite defaultResponseSprite;
    [SerializeField] Sprite answerSprite;

    void Start()
    {
        questionText.text = question.GetQuestion();
        
        for (int i = 0; i < responseButtons.Length; i++) {
            TextMeshProUGUI buttonText = responseButtons[i].GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = question.GetResponse(i);
        }
    }

    public void OnResponseSelected(int index) {
        Image buttonImage;
        if (index == question.GetAnswerIndex()) {
            questionText.text = "Correct!";
            buttonImage = responseButtons[index].GetComponent<Image>();
            buttonImage.sprite = answerSprite;
        } else {
            answerIndex = question.GetAnswerIndex();
            string answer = question.GetResponse(answerIndex);
            questionText.text = "Wrong..." + answer;
            buttonImage = responseButtons[answerIndex].GetComponent<Image>();
            buttonImage.sprite = answerSprite;
        }
    }
}