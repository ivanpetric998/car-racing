using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    private static bool pauseOn=false;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            StopStart();
        }
    }

    public void StopStart()
    {
        if(pauseOn)
        {
            Resume();
        }
        else
        {
            Stop();
        }
    }

    private void Stop()
    {
        Time.timeScale = 0f;
        pauseOn=true;
    }

    private void Resume()
    {
            Time.timeScale = 1f;
            pauseOn=false;
    }
}
