using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private Slider timer;

    public float initialMaxTime;
    public float currentMaxTime;
    public float maxTimePercentage;
    public float currentTime;
    private float timerPercentage;

    public int amountOfClothes;

    public AnimationCurve reduceMaxTime;


    void Start()
    {
        timer = GetComponent<Slider>();
        currentTime = initialMaxTime;
    }
    void Update()
    {
        RunTimer();
        CheckTimer();

        CalculateTimerPercentage();
        SetTimerProgress();
    }

    private void RunTimer()
    {
        currentTime -= Time.deltaTime;
    }

    private void CheckTimer()
    {
        if(currentTime <= 0)
        {
            currentTime = currentMaxTime;
            amountOfClothes++;
            CalculateCurrentMaxtime();
        }
    }

    private void CalculateCurrentMaxtime()
    {
        maxTimePercentage = reduceMaxTime.Evaluate(amountOfClothes) / 200;

        currentMaxTime = initialMaxTime * maxTimePercentage;
    }

    private void CalculateTimerPercentage()
    {
        timerPercentage = currentTime / currentMaxTime;
    }

    public void SetTimerProgress()
    {
        timer.value = timerPercentage;
    }
}
