using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Quiz Question", fileName = "New Question")]
public class QuestionSO : ScriptableObject
{
    [TextArea(2, 6)]
    [SerializeField] string question = "Enter new question text here";
    [SerializeField] string[] responses = new string[4];
    [SerializeField] int answerIndex;


    public string GetQuestion() {
        return question;
    }

    public string GetResponse(int index) {
        return responses[index];
    }

    public int GetAnswerIndex() {
        return answerIndex;
    }
}
