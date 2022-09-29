using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
    int answerCount = 0;
    int questionsSeen = 0;
    
    public int GetAnswerCount() {
        return answerCount;
    }

    public void IncrementAnswerCount() {
        answerCount++;
    }

    public int GetQuestionsSeen() {
        return questionsSeen;
    }

    public void IncrementQuestionsSeen() {
        questionsSeen++;
    }

    public int CalculateScore() {
        return Mathf.RoundToInt(answerCount / (float)questionsSeen * 100);
    }
}
