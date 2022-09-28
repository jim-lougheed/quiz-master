using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float timeToComplete = 30f;
    [SerializeField] float timeToShowAnswer = 10f;
    public bool questionActive = false;
    float timerValue;

    // Update is called once per frame
    void Update()
    {
        UpdateTimer();
    }

    void UpdateTimer() {
        timerValue -= Time.deltaTime;
        if (timerValue <= 0) {
            if (questionActive) {
                timerValue = timeToShowAnswer;
            } else {
                timerValue = timeToComplete;
            }
            questionActive = !questionActive;
        }
        Debug.Log(timerValue);
    }
}
