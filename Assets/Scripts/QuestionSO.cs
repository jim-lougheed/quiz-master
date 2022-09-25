using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Quiz Question", fileName = "New Question")]
public class QuestionSO : ScriptableObject
{
    [TextArea(2, 6)]
    [SerializeField] string question = "Enter new question text here";
    [SerializeField] string[] responses = new string[4];
    [SerializeField] int correctResponseIndex;


    public string GetQuestion() {
        return question;
    }

    public int GetCorrectResponseIndex() {
        return correctResponseIndex;
    }

    public string GetAnswer(int index) {
        return responses[index];
    }
}
