using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseTest : MonoBehaviour
{
    bool isPaused;
    public void Pause()
    {
        if(isPaused)
        {
            Time.timeScale = 1;
            isPaused = false;
        }
        else
        {
            Time.timeScale = 0;
            isPaused = true;
        }
    }
}
