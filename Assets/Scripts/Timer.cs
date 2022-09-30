using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float timeToComplete = 30f;
    [SerializeField] float timeToShowAnswer = 10f;
    public bool questionActive = false;
    public float fillFraction;
    public bool loadNextQuestion;
    float timerValue;

    // Update is called once per frame
    void Update()
    {
        UpdateTimer();
    }

    public void CancelTimer() {
        timerValue = 0;
    }

    void UpdateTimer() {
        timerValue -= Time.deltaTime;
        if (timerValue > 0) {
            fillFraction = timerValue / timeToComplete;
            if (questionActive) {
                fillFraction = timerValue / timeToComplete;
            } else {
                fillFraction = timerValue / timeToShowAnswer;
            }

        } else {
            if (questionActive) {
                timerValue = timeToShowAnswer;
            } else {
                timerValue = timeToComplete;
                loadNextQuestion = true;
            }
            questionActive = !questionActive;
        }
    }
}
