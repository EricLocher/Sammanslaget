using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    public float initialMaxTime;
    public float currentMaxTime;
    public float maxTimePercentage;
    public float currentTime;
    
    public float timerPercentage = 0.002f;

    public int iterations;
    public int maxIterations;

    public AnimationCurve reduceMaxTime;

    [SerializeField] private UnityEvent OnTimeOut;


    void Start()
    {
        currentTime = initialMaxTime;
    }
    void Update()
    {
        RunTimer();
        CheckTimer();
    }

    private void RunTimer()
    {
        currentTime -= Time.deltaTime;
    }

    private void CheckTimer()
    {
        if(currentTime <= 0)
        {
            OnTimeOut.Invoke();
            currentTime = currentMaxTime;
            iterations++;
            SetTimerPercentage();
            CalculateCurrentMaxtime();                
        }
    }

    private void CalculateCurrentMaxtime()
    {
        maxTimePercentage = reduceMaxTime.Evaluate(timerPercentage);

        currentMaxTime = initialMaxTime * maxTimePercentage;
    }

    private void SetTimerPercentage()
    {
        if(iterations != 0) timerPercentage = (float)iterations / (float)maxIterations;
    }

    public void ResetValues()
    {
        currentMaxTime = initialMaxTime;
        currentTime = initialMaxTime;
        maxTimePercentage = 1;
        timerPercentage = 0.002f;
        iterations = 0;
    }

}
