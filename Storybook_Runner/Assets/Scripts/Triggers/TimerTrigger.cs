using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TimerTrigger : MonoBehaviour
{
    [SerializeField]
    private UnityEvent OnTimerFinished;

    [SerializeField]
    private float timeInSeconds;

    private bool isTimerStarted;

    private float timeAccumulated;

    void Update()
    {
        if (isTimerStarted)
        {        
            timeAccumulated += Time.deltaTime;
            if (timeAccumulated >= timeInSeconds)
            {
                isTimerStarted = false;
                OnTimerFinished?.Invoke();
                timeAccumulated = 0;
            }
        }
    }

    public void StartTimer()
    {
        isTimerStarted = true; 
    }

    private void OnDisable()
    {
        timeAccumulated = 0;
        isTimerStarted = false;
    }
}