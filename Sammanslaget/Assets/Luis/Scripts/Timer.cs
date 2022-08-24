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
    private float timerPercentage;

    public int iterations;

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
            CalculateCurrentMaxtime();
        }
    }

    private void CalculateCurrentMaxtime()
    {
        maxTimePercentage = reduceMaxTime.Evaluate(iterations) / 200;

        currentMaxTime = initialMaxTime * maxTimePercentage;
    }
}
